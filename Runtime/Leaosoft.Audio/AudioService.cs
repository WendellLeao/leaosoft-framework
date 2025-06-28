using System.Collections.Generic;
using Leaosoft.Services;
using Leaosoft.Pooling;
using UnityEngine;

namespace Leaosoft.Audio
{
    /// <summary>
    /// The AudioService provides the abstraction <see cref="IAudioService"/> to play a sound anywhere in the game.
    /// <seealso cref="ServiceLocator"/>
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class AudioService : GameService, IAudioService
    {
        [Header("Sound Player")]
        [SerializeField]
        private PoolData soundPlayerPool;

        [Header("Data")]
        [SerializeField]
        private AudioDataCollection audioDataCollection;

        private readonly Dictionary<string, AudioData> _audioDataDictionary = new();
        private readonly List<SoundPlayer> _allActiveSoundPlayers = new();

        public void PlaySound(string audioId, Vector3 position)
        {
            if (!_audioDataDictionary.TryGetValue(audioId, out AudioData audioData))
            {
                Debug.LogError($"Couldn't find any AudioData with id '{audioId}'!");
                return;
            }

            if (!CanPlaySound(audioData))
            {
                return;
            }

            SoundPlayer soundPlayer = GetSoundPlayerFromPool(soundPlayerPool.Id);

            BeginSoundPlayer(position, soundPlayer, audioData);
        }

        protected override void RegisterService()
        {
            ServiceLocator.RegisterService<IAudioService>(this);
        }

        protected override void UnregisterService()
        {
            ServiceLocator.UnregisterService<IAudioService>();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach (AudioData audioData in audioDataCollection.AudioData)
            {
                audioData.SetIsPlaying(false);

                _audioDataDictionary.Add(audioData.Id, audioData);
            }
        }

        protected override void OnDispose()
        {
            base.OnDispose();

            foreach (SoundPlayer activeSoundPlayer in _allActiveSoundPlayers)
            {
                StopSoundPlayer(activeSoundPlayer);
            }
        }

        private void BeginSoundPlayer(Vector3 position, SoundPlayer soundPlayer, AudioData audioData)
        {
            soundPlayer.OnClipFinished += StopSoundPlayer;

            soundPlayer.Begin(audioData, position);
            
            _allActiveSoundPlayers.Add(soundPlayer);
        }
        
        private void StopSoundPlayer(SoundPlayer soundPlayer)
        {
            soundPlayer.OnClipFinished -= StopSoundPlayer;
            
            soundPlayer.Stop();
            
            _allActiveSoundPlayers.Remove(soundPlayer);
        }
        
        private bool CanPlaySound(AudioData audioData)
        {
            if (!audioData.PersistentSound)
            {
                return true;
            }

            if (!audioData.IsPlaying)
            {
                return true;
            }

            return false;
        }

        private SoundPlayer GetSoundPlayerFromPool(string soundPlayerId)
        {
            IPoolingService poolingService = ServiceLocator.GetService<IPoolingService>();

            GameObject soundPlayerGameObject = poolingService.GetObjectFromPool(soundPlayerId);

            SoundPlayer soundPlayer = soundPlayerGameObject.GetComponent<SoundPlayer>();

            return soundPlayer;
        }
    }
}

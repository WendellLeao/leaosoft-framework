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
        [SerializeField]
        private AudiosDataCollection _audiosDataCollection;

        [Header("Sound Player")]
        [SerializeField]
        private PoolData _soundPlayerPool;

        private readonly Dictionary<string, AudioData> _audioDataDictionary = new();

        public void PlaySound(string audioId, Vector3 position)
        {
            if (!_audioDataDictionary.TryGetValue(audioId, out AudioData audioData))
            {
                Debug.LogError($"Couldn't find any AudioData with id '{audioId}'");
                return;
            }

            if (!CanPlaySound(audioData))
            {
                return;
            }

            SoundPlayer soundPlayer = GetSoundPlayerFromPool(_soundPlayerPool.Id);

            soundPlayer.PlaySound(audioData, position);

            audioData.SetIsPlaying(true);
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

            foreach (AudioData audioData in _audiosDataCollection.AudiosData)
            {
                audioData.SetIsPlaying(false);

                _audioDataDictionary.Add(audioData.Id, audioData);
            }
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

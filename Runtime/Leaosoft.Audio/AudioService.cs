using System.Collections.Generic;
using Leaosoft.Services;
using Leaosoft.Pooling;
using UnityEngine;

namespace Leaosoft.Audio
{
    /// <summary>
    /// The AudioService provides the abstraction <see cref="IAudioService"/> to play a sound anywhere in the project.
    /// <seealso cref="ServiceLocator"/>
    /// </summary>
    
    [DisallowMultipleComponent]
    public sealed class AudioService : GameService, IAudioService
    {
        [SerializeField] private AudioData[] _audiosData;
        
        [Header("Sound Player")]
        [SerializeField] private PoolData _soundPlayerPool;
        
        private Dictionary<string, AudioData> _audioDataDictionary;
        
        public void RegisterService()
        {
            ServiceLocator.RegisterService<IAudioService>(this);
        }

        public void UnregisterService()
        {
            ServiceLocator.DeregisterService<IAudioService>();
        }

        public void Initialize()
        {
            _audioDataDictionary = new Dictionary<string, AudioData>();

            foreach (AudioData audioData in _audiosData)
            {
                audioData.IsPlaying = false;

                _audioDataDictionary.Add(audioData.Id, audioData);
            }
        }
        
        public void PlaySound(string audioId, Vector3 position)
        {
            if (_audioDataDictionary.TryGetValue(audioId, out AudioData audioData))
            {
                if (!CanPlaySound(audioData))
                {
                    return;
                }

                SoundPlayer soundPlayer = GetSoundPlayerFromPool(_soundPlayerPool.Id);

                soundPlayer.PlaySound(audioData, position);

                audioData.IsPlaying = true;
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

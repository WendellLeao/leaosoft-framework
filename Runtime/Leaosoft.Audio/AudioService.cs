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
    public sealed class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField] private AudioData[] _audiosData;

        private Dictionary<Sound, AudioData> _audioDataDictionary;

        public void RegisterService()
        {
            ServiceLocator.RegisterService<IAudioService>(this);
        }

        public void UnregisterService()
        {
            ServiceLocator.DeregisterService<IAudioService>();
        }
            
        public void PlaySound(Sound sound, Vector3 position)
        {
            if (_audioDataDictionary.TryGetValue(sound, out AudioData audioData))
            {
                if (!CanPlaySound(audioData))
                {
                    return;
                }

                SoundPlayer soundPlayer = GetSoundPlayerFromPool();

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

        private SoundPlayer GetSoundPlayerFromPool()
        {
            IPoolingService poolingService = ServiceLocator.GetService<IPoolingService>();

            GameObject soundPlayerGameObject = poolingService.GetObjectFromPool(PoolType.SoundPlayer);

            SoundPlayer soundPlayer = soundPlayerGameObject.GetComponent<SoundPlayer>();

            return soundPlayer;
        }

        private void Awake()
        {
            _audioDataDictionary = new Dictionary<Sound, AudioData>();

            foreach (AudioData audioData in _audiosData)
            {
                audioData.IsPlaying = false;

                _audioDataDictionary.Add(audioData.Sound, audioData);
            }
        }
    }
}

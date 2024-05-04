using Random = UnityEngine.Random;
using Cysharp.Threading.Tasks;
using Leaosoft.Services;
using Leaosoft.Pooling;
using UnityEngine;
using System;

namespace Leaosoft.Audio
{
    [DisallowMultipleComponent, RequireComponent(typeof(AudioSource))]
    public sealed class SoundPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource;
        [SerializeField]
        private PoolData _soundPlayerPool;

        private AudioData _audioData;

        public void PlaySound(AudioData audioData, Vector3 position)
        {
            SetAndPlayAudioSource(audioData);

            transform.position = position;
        }

        private void OnDisable()
        {
            IPoolingService poolingService = ServiceLocator.GetService<IPoolingService>();
            
            poolingService.ReturnObjectToPool(_soundPlayerPool.Id, gameObject);

            if (_audioData != null)
            {
                _audioData.SetIsPlaying(false);
            }
        }

        private void SetAndPlayAudioSource(AudioData audioData)
        {
            SetAudioData(audioData);

            _audioSource.Play();

            if (_audioSource.loop)
            {
                return;
            }

            DeactivateSoundGameObjectAsync();
        }

        private async void DeactivateSoundGameObjectAsync()
        {
            float clipDuration = _audioSource.clip.length;
                
            await UniTask.Delay(TimeSpan.FromSeconds(clipDuration));
                
            gameObject.SetActive(false);
        }
        
        private void SetAudioData(AudioData audioData)
        {
            _audioData = audioData;

            int randomIndex = Random.Range(0, audioData.AudioClips.Length);
            
            _audioSource.clip = audioData.AudioClips[randomIndex];

            _audioSource.volume = audioData.Volume;

            _audioSource.pitch = audioData.Pitch;

            _audioSource.spatialBlend = audioData.SpatialBlend;

            _audioSource.loop = audioData.Loop;

            _audioSource.outputAudioMixerGroup = audioData.AudioMixerGroup;

            if (audioData.PersistentSound)
            {
                transform.SetParent(null);
                
                DontDestroyOnLoad(_audioSource.gameObject);
            }
        }
    }
}

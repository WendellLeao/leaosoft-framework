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
        private AudioSource audioSource;
        [SerializeField]
        private PoolData soundPlayerPool;

        private AudioData _audioData;

        public void PlaySound(AudioData audioData, Vector3 position)
        {
            SetAndPlayAudioSource(audioData);

            transform.position = position;
        }

        private void OnDisable()
        {
            IPoolingService poolingService = ServiceLocator.GetService<IPoolingService>();

            poolingService.ReturnObjectToPool(soundPlayerPool.Id, gameObject);

            if (_audioData is not null)
            {
                _audioData.SetIsPlaying(false);
            }
        }

        private void SetAndPlayAudioSource(AudioData audioData)
        {
            SetAudioData(audioData);

            audioSource.Play();

            if (audioSource.loop)
            {
                return;
            }

            DeactivateSoundGameObjectAsync();
        }

        private async void DeactivateSoundGameObjectAsync()
        {
            float clipDuration = audioSource.clip.length;

            await UniTask.Delay(TimeSpan.FromSeconds(clipDuration));

            gameObject.SetActive(false);
        }

        private void SetAudioData(AudioData audioData)
        {
            _audioData = audioData;

            int randomIndex = Random.Range(0, audioData.AudioClips.Length);

            audioSource.clip = audioData.AudioClips[randomIndex];

            audioSource.volume = audioData.Volume;

            audioSource.pitch = audioData.Pitch;

            audioSource.spatialBlend = audioData.SpatialBlend;

            audioSource.loop = audioData.Loop;

            audioSource.outputAudioMixerGroup = audioData.AudioMixerGroup;

            if (audioData.PersistentSound)
            {
                transform.SetParent(null);

                DontDestroyOnLoad(audioSource.gameObject);
            }
        }
    }
}

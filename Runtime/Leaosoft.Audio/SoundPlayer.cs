using Random = UnityEngine.Random;
using Cysharp.Threading.Tasks;
using Leaosoft.Services;
using Leaosoft.Pooling;
using UnityEngine;
using System;
using System.Threading;

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
        private CancellationTokenSource _deactivateSoundGameObjectCts;

        public void PlaySound(AudioData audioData, Vector3 position)
        {
            SetAudioData(audioData);
            
            SetupAudioSource(audioData);
            
            PlayAudioSource();

            transform.position = position;
        }

        private void OnDisable()
        {
            IPoolingService poolingService = ServiceLocator.GetService<IPoolingService>();

            poolingService.ReturnObjectToPool(soundPlayerPool.Id, gameObject);

            if (_audioData != null)
            {
                _audioData.SetIsPlaying(false);
            }
        }

        private void OnDestroy()
        {
            DisposeDeactivateSoundGameObjectCts();
        }

        private void PlayAudioSource()
        {
            audioSource.Play();

            if (audioSource.loop)
            {
                return;
            }
            
            _deactivateSoundGameObjectCts = new CancellationTokenSource();

            DeactivateSoundGameObjectAsync(_deactivateSoundGameObjectCts.Token);
        }

        private async void DeactivateSoundGameObjectAsync(CancellationToken token)
        {
            try
            {
                float clipDuration = audioSource.clip.length;

                await UniTask.Delay(TimeSpan.FromSeconds(clipDuration), cancellationToken: token);

                gameObject.SetActive(false);
            }
            catch (OperationCanceledException e)
            {
                Debug.LogWarning($"The operation was canceled when trying to deactivate the sound GameObject: {e}",
                    gameObject);
            }
            catch (Exception e)
            {
                Debug.LogError($"Unexpected error when trying to deactivate the sound GameObject: {e}", gameObject);
            }
            finally
            {
                DisposeDeactivateSoundGameObjectCts();
            }
        }

        private void DisposeDeactivateSoundGameObjectCts()
        {
            _deactivateSoundGameObjectCts?.Cancel();
            _deactivateSoundGameObjectCts?.Dispose();
            _deactivateSoundGameObjectCts = null;
        }
        
        private void SetAudioData(AudioData audioData)
        {
            _audioData = audioData;
        }

        private void SetupAudioSource(AudioData audioData)
        {
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

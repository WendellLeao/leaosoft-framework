using Random = UnityEngine.Random;
using Cysharp.Threading.Tasks;
using Leaosoft.Services;
using Leaosoft.Pooling;
using UnityEngine;
using System;
using System.Threading;

namespace Leaosoft.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class SoundPlayer : Entity
    {
        public event Action<SoundPlayer> OnClipFinished;
        
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private PoolData soundPlayerPool;

        private AudioData _audioData;
        private CancellationTokenSource _handleClipLengthCts;

        public void Begin(AudioData audioData, Vector3 position)
        {
            _audioData = audioData;
            
            SetupAudioSource(audioData);
            
            audioData.SetIsPlaying(true);
            
            transform.position = position;
            
            PlayAudioSource();
            
            base.Begin();
        }

        protected override void OnStop()
        {
            base.OnStop();
            
            IPoolingService poolingService = ServiceLocator.GetService<IPoolingService>();

            poolingService.ReturnObjectToPool(soundPlayerPool.Id, gameObject);
            
            if (_audioData)
            {
                _audioData.SetIsPlaying(false);
            }
            
            DisposeHandleClipLengthCts();
        }

        private void PlayAudioSource()
        {
            audioSource.Play();

            if (audioSource.loop)
            {
                return;
            }
            
            _handleClipLengthCts = new CancellationTokenSource();

            HandleClipLengthAsync(_handleClipLengthCts.Token);
        }

        private async void HandleClipLengthAsync(CancellationToken token)
        {
            try
            {
                float clipDuration = audioSource.clip.length;

                await UniTask.Delay(TimeSpan.FromSeconds(clipDuration), cancellationToken: token);
                
                OnClipFinished?.Invoke(this);
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
                DisposeHandleClipLengthCts();
            }
        }

        private void DisposeHandleClipLengthCts()
        {
            _handleClipLengthCts?.Cancel();
            _handleClipLengthCts?.Dispose();
            _handleClipLengthCts = null;
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

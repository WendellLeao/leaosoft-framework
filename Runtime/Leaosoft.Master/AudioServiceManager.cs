using Leaosoft.Pooling;
using Leaosoft.Audio;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class AudioServiceManager : Manager
    {
        [Header("Service")]
        [SerializeField] private AudioService _audioService;
        [SerializeField] private AudioData[] _audiosData;
        
        [Header("Pool")]
        [SerializeField] private PoolData _soundPlayer;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            InitializeAudioService();
        }

        private void InitializeAudioService()
        {
            AudioService audioServiceClone = Instantiate(_audioService);
            
            audioServiceClone.RegisterService();
            
            audioServiceClone.Initialize(_audiosData, _soundPlayer);
        }
    }
}

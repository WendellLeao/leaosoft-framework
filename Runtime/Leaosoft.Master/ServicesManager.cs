using Leaosoft.Pooling;
using Leaosoft.Events;
using Leaosoft.Audio;
using Leaosoft.Save;
using Leaosoft.UI;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class ServicesManager : Manager
    {
        [Header("Audio Service")] 
        [SerializeField] private AudioService _audioService;
        [SerializeField] private PoolData _soundPlayer;
        [SerializeField] private AudioData[] _audiosData;
        
        [Header("Pooling Service")]
        [SerializeField] private PoolingService _poolingService;
        [SerializeField] private PoolData[] _poolsData;

        [Header("Screen Service")] 
        [SerializeField] private ScreenService _screenService;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            InitializeAudioService();

            InitializePoolingService();

            InitializeScreenService();
                
            InitializeSaveService();

            InitializeEventService();
        }

        private void InitializePoolingService()
        {
            PoolingService poolingServiceClone = Instantiate(_poolingService);
            
            poolingServiceClone.RegisterService();
            
            poolingServiceClone.Initialize(_poolsData);
        }
        
        private void InitializeAudioService()
        {
            AudioService audioServiceClone = Instantiate(_audioService);
            
            audioServiceClone.RegisterService();
            
            audioServiceClone.Initialize(_audiosData, _soundPlayer);
        }

        private void InitializeScreenService()
        {
            ScreenService screenServiceClone = Instantiate(_screenService);
            
            screenServiceClone.RegisterService();
        }
        
        private void InitializeSaveService()
        { 
            ISaveService newSaveService = new SaveService();

            newSaveService.RegisterService();
        }
        
        private void InitializeEventService()
        {
            IEventService newEventService = new EventService();

            newEventService.RegisterService();
        }
    }
}

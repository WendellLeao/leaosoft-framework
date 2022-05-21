using Game.Services;
using Game.Pooling;
using Game.Events;
using UnityEngine;
using Game.Audio;
using Game.Input;
using Game.Save;
using Game.UI;

namespace Game.Master
{
    public static class ServicesInitializator
    {
        private const string PoolingServicePrefabPath = "GameServices/PoolingService/PoolingService";
        private const string AudioServicePrefabPath = "GameServices/AudioService/AudioService";
        private const string UIServicePrefabPath = "GameServices/UIService/UIService";
        private const string InputServicePrefabPath = "GameServices/InputService/InputService";
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeServices()
        {
            if (ServiceLocator.GetService<IPoolingService>() == null)
            {
                InitializePoolingService();
            }

            if (ServiceLocator.GetService<IAudioService>() == null)
            {
                InitializeAudioService();
            }

            if (ServiceLocator.GetService<IUIService>() == null)
            {
                InitializeUIService();
            }

            if (ServiceLocator.GetService<IInputService>() == null)
            {
                InitializeInputService();
            }
            
            if (ServiceLocator.GetService<ISaveService>() == null)
            {
                InitializeSaveService();
            }
            
            if (ServiceLocator.GetService<IEventService>() == null)
            {
                InitializeEventService();
            }
        }

        private static void InitializePoolingService()
        {
            GameObject poolingServicePrefab = Resources.Load(PoolingServicePrefabPath) as GameObject;
                
            Object.Instantiate(poolingServicePrefab);
        }
        
        private static void InitializeAudioService()
        {
            GameObject audioServicePrefab = Resources.Load(AudioServicePrefabPath) as GameObject;
                
            Object.Instantiate(audioServicePrefab);
        }

        private static void InitializeUIService()
        {
            GameObject uiServicePrefab = Resources.Load(UIServicePrefabPath) as GameObject;
                
            Object.Instantiate(uiServicePrefab);
        }
        
        private static void InitializeInputService()
        {
            GameObject inputServicePrefab = Resources.Load(InputServicePrefabPath) as GameObject;
                
            Object.Instantiate(inputServicePrefab);
        }
        
        private static void InitializeSaveService()
        { 
            ISaveService newSaveService = new SaveService(); 
            
            ServiceLocator.RegisterService(newSaveService);
        }
        
        private static void InitializeEventService()
        {
            IEventService newEventService = new EventService();
            
            ServiceLocator.RegisterService(newEventService);
        }
    }
}

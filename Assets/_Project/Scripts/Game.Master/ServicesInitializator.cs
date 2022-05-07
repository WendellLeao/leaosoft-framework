using Game.Services;
using Game.Pooling;
using Game.Events;
using UnityEngine;
using Game.Audio;
using Game.Input;
using Game.UI;

namespace Game.Master
{
    public static class ServicesInitializator
    {
        private const string PoolingServicePrefabPath = "ServiceLocator/PoolingService/PoolingService";
        private const string AudioServicePrefabPath = "ServiceLocator/AudioService/AudioService";
        private const string UIServicePrefabPath = "ServiceLocator/UIService/UIService";
        private const string InputServicePrefabPath = "ServiceLocator/InputService/InputService";
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeServices()
        {
            if (ServiceLocator.GetService<IPoolingService>() == null)
            {
                CheckAndInitializePoolingService();
            }

            if (ServiceLocator.GetService<IAudioService>() == null)
            {
                CheckAndInitializeAudioService();
            }

            if (ServiceLocator.GetService<IUIService>() == null)
            {
                CheckAndInitializeUIService();
            }

            if (ServiceLocator.GetService<IInputService>() == null)
            {
                CheckAndInitializeInputService();
            }
            
            if (ServiceLocator.GetService<IEventService>() == null)
            {
                CheckAndInitializeEventService();
            }
        }

        private static void CheckAndInitializePoolingService()
        {
            GameObject poolingServicePrefab = Resources.Load(PoolingServicePrefabPath) as GameObject;
                
            Object.Instantiate(poolingServicePrefab);
        }
        
        private static void CheckAndInitializeAudioService()
        {
            GameObject audioServicePrefab = Resources.Load(AudioServicePrefabPath) as GameObject;
                
            Object.Instantiate(audioServicePrefab);
        }

        private static void CheckAndInitializeUIService()
        {
            GameObject uiServicePrefab = Resources.Load(UIServicePrefabPath) as GameObject;
                
            Object.Instantiate(uiServicePrefab);
        }
        
        private static void CheckAndInitializeInputService()
        {
            GameObject inputServicePrefab = Resources.Load(InputServicePrefabPath) as GameObject;
                
            Object.Instantiate(inputServicePrefab);
        }
        
        private static void CheckAndInitializeEventService()
        {
            IEventService newEventService = new EventService();
            
            ServiceLocator.RegisterService(newEventService);
        }
    }
}

using Leaosoft.Services;
using Leaosoft.Pooling;
using Leaosoft.Events;
using Leaosoft.Audio;
using Leaosoft.Input;
using Leaosoft.Save;
using Leaosoft.UI;
using UnityEngine;

namespace Leaosoft.Master
{
    public static class ServicesInitializer
    {
        private const string PoolingServicePrefabPath = "GameServices/PoolingService/PoolingService";
        private const string AudioServicePrefabPath = "GameServices/AudioService/AudioService";
        private const string UIServicePrefabPath = "GameServices/ScreenService/ScreenService";
        private const string InputServicePrefabPath = "GameServices/InputService/InputService";

        private static bool _hasInitializedServices;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeServices()
        {
            if (_hasInitializedServices)
            {
                return;
            }
            
            if (ServiceLocator.GetService<IPoolingService>() == null)
            {
                InitializePoolingService();
            }

            if (ServiceLocator.GetService<IAudioService>() == null)
            {
                InitializeAudioService();
            }

            if (ServiceLocator.GetService<IScreenService>() == null)
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

            _hasInitializedServices = true;
        }

        private static void InitializePoolingService()
        {
            GameObject poolingServicePrefab = Resources.Load(PoolingServicePrefabPath) as GameObject;
                
            GameObject serviceObject = Object.Instantiate(poolingServicePrefab);
            
            serviceObject.GetComponent<IGameService>().RegisterService();
        }
        
        private static void InitializeAudioService()
        {
            GameObject audioServicePrefab = Resources.Load(AudioServicePrefabPath) as GameObject;
                
            GameObject serviceObject = Object.Instantiate(audioServicePrefab);
            
            serviceObject.GetComponent<IGameService>().RegisterService();
        }

        private static void InitializeUIService()
        {
            GameObject uiServicePrefab = Resources.Load(UIServicePrefabPath) as GameObject;
                
            GameObject serviceObject = Object.Instantiate(uiServicePrefab);
            
            serviceObject.GetComponent<IGameService>().RegisterService();
        }
        
        private static void InitializeInputService()
        {
            GameObject inputServicePrefab = Resources.Load(InputServicePrefabPath) as GameObject;
                
            GameObject serviceObject = Object.Instantiate(inputServicePrefab);
            
            serviceObject.GetComponent<IGameService>().RegisterService();
        }
        
        private static void InitializeSaveService()
        { 
            ISaveService newSaveService = new SaveService();

            newSaveService.RegisterService();
        }
        
        private static void InitializeEventService()
        {
            IEventService newEventService = new EventService();

            newEventService.RegisterService();
        }
    }
}

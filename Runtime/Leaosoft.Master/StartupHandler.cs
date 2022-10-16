using UnityEngine.SceneManagement;
using Leaosoft.Events;
using Leaosoft.Save;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class StartupHandler : MonoBehaviour
    {
        [SerializeField] private AudioServiceManager _audioServiceManager;
        [SerializeField] private PoolingServiceManager _poolingServiceManager;
        [SerializeField] private ScreenServiceManager _screenServiceManager;
        
        private void Awake()
        {
            InitializeServices();

            HandleInitialization();
        }

        private void InitializeServices()
        {
            InitializeSaveService();

            InitializeEventService();

            _audioServiceManager.Initialize();
            
            _poolingServiceManager.Initialize();
            
            _screenServiceManager.Initialize();
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

        private void HandleInitialization()
        {
            if (StartupSceneLoader.HasLoadStartupScene)
            {
                LoadFirstLoadedScene();
                
                return;
            }
            
            InitializeGame();
        }

        private void InitializeGame()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            SceneManager.LoadSceneAsync(nextSceneIndex);
        }

        private void LoadFirstLoadedScene()
        {
            SceneManager.LoadSceneAsync(StartupSceneLoader.FirstLoadedSceneIndex);
        }
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class StartupHandler : MonoBehaviour
    {
        [SerializeField] private ServicesRegister _servicesRegister;
        
        private void Awake()
        {
            _servicesRegister.Initialize();

            HandleStartupScene();
        }

        private void HandleStartupScene()
        {
            if (StartupSceneLoader.HasLoadStartupScene)
            {
                LoadFirstLoadedScene();
                
                return;
            }
            
            StartGame();
        }

        private void StartGame()
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

using UnityEngine.SceneManagement;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class StartupHandler : MonoBehaviour
    {
        [SerializeField] private AudiosManager _audiosManager;
        [SerializeField] private PoolsManager _poolsManager;
        
        private void Awake()
        {
            _audiosManager.Initialize();
            _poolsManager.Initialize();
            
            HandleInitialization();
            
            Debug.Log("<color=white>Leaosoft - The game has been successfully initialized!</color>");
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
            SceneManager.LoadSceneAsync(StartupSceneLoader.FirstLoadedSceneName);
        }
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class StartupHandler : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60; //TODO: Unlock the frame rate

            if (StartupSceneLoader.HasLoadStartupScene)
            {
                LoadFirstLoadedScene();
            }
            else
            {
                InitializeGame();
            }
            
            Debug.Log("Leaosoft - The game has been successfully initialized!");
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

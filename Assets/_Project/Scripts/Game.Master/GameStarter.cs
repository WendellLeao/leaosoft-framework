using UnityEngine.SceneManagement;
using Game.Services;
using UnityEngine;
using Game.UI;

namespace Game.Master
{
    public class GameStarter : MonoBehaviour
    {
        private void Awake()
        {
            ILogger logger = Debug.unityLogger;
            
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            logger.logEnabled = true;
#else
            logger.logEnabled = false;
#endif
            Application.targetFrameRate = 60;//TODO: UNLOCK FRAME RATE
            
            StartGame();
        }

        private void StartGame()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneIndex);

            IUIService uiService = ServiceLocator.GetService<IUIService>();
            
            uiService.OpenLoadingScreen(operation);
        }
    }
}

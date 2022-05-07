using UnityEngine.SceneManagement;
using UnityEngine;

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
            
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}

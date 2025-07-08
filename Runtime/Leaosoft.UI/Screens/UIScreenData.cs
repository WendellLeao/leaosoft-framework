using Leaosoft.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leaosoft.UI.Screens
{
    [CreateAssetMenu(menuName = PathUtility.ScreenAssetsPath + "/UIScreenData", fileName = "NewUIScreenData")]
    public sealed class UIScreenData : ScriptableObject
    {
        [SerializeField]
        private string id;
        [SerializeField]
        private string sceneName; // TODO: improve this
        [SerializeField]
        private LoadSceneMode loadSceneMode; // TODO: it doesn't load, but hides the others in case its single

        public string Id => id;
        public string SceneName => sceneName;
        public LoadSceneMode LoadSceneMode => loadSceneMode;
    }
}

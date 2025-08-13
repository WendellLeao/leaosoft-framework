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
        private ScreenType screenType;

        public string Id => id;
        public string SceneName => sceneName;
        public ScreenType ScreenType => screenType;
    }
}

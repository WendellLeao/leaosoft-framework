using Game.UI.Screens;
using UnityEngine;

namespace Game.UI
{
    public interface IUIService
    {
        UIScreen CurrentOpenedScreen { get; }
        UIScreen OpenScreen(UIScreen uiScreen, OpenScreenMode openScreenMode = OpenScreenMode.Single, float delay = 0);
        UIScreen OpenScreen<T>(OpenScreenMode openScreenMode = OpenScreenMode.Single, float delay = 0) where T : UIScreen;
        void OpenLoadingScreen(AsyncOperation operation);
        void CloseTopScreen();
        void CloseAllScreens();
        void RegisterScreen(UIScreen uiScreen);
        void UnregisterScreen(UIScreen uiScreen);
        UIScreen GetRegisteredScreen<T>() where T : UIScreen;
    }
}

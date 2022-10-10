using Screen = Leaosoft.UI.Screens.Screen;
using Leaosoft.Master;

namespace Leaosoft.UI
{
    public interface IScreenService : IGameService
    {
        Screen CurrentOpenedScreen { get; }
        Screen OpenScreen(Screen screen, OpenScreenMode openScreenMode = OpenScreenMode.Single, float delay = 0);
        Screen OpenScreen<T>(OpenScreenMode openScreenMode = OpenScreenMode.Single, float delay = 0) where T : Screen;
        void CloseTopScreen();
        void CloseAllScreens();
        void RegisterScreen(Screen screen);
        void UnregisterScreen(Screen screen);
        Screen GetRegisteredScreen<T>() where T : Screen;
    }
}

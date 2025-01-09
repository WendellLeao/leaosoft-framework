using Leaosoft.Services;
using Leaosoft.UI.Screens;

namespace Leaosoft.UI
{
    public interface IScreenService : IGameService
    {
        public void RegisterScreen(IUIScreen uiScreen);

        public void UnregisterScreen(IUIScreen uiScreen);

        public void OpenScreen<T>(bool additive = true) where T : IUIScreen;

        public void CloseScreenOnTop();
    }
}

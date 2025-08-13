using Cysharp.Threading.Tasks;
using Leaosoft.Services;
using Leaosoft.UI.Screens;

namespace Leaosoft.UI
{
    public interface IScreenService : IGameService
    {
        public UniTask<IUIScreen> OpenScreenAsync(UIScreenData screenData);
    }
}

using System;

namespace Leaosoft.UI.Screens
{
    public interface IUIScreen
    {
        public event Action<IUIScreen> OnCloseRequested;

        public UIScreenData Data { get; }
        
        public void Open();

        public void Close();

        public void Tick(float deltaTime);

        public void Show();
        
        public void Hide();
    }
}

using System;

namespace Leaosoft.UI.Screens
{
    public interface IUIScreen
    {
        public event Action<IUIScreen> OnOpened;

        public event Action<IUIScreen> OnClosed;

        public string Id { get; }
        
        public void Open();

        public void Close();

        public void Show();

        public void Hide();
    }
}

using System.Collections.Generic;
using Leaosoft.Services;
using Leaosoft.UI.Screens;
using UnityEngine;

namespace Leaosoft.UI
{
    /// <summary>
    /// The ScreenService provides the abstraction <see cref="IScreenService"/> to open or close screens.
    /// <seealso cref="ServiceLocator"/>
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class ScreenService : GameService, IScreenService
    {
        private readonly List<IUIScreen> _registeredScreens = new();
        private readonly Stack<IUIScreen> _openedScreens = new();

        public void RegisterScreen(IUIScreen screen)
        {
            if (_registeredScreens.Contains(screen))
            {
                Debug.LogWarning($"The screen '{screen.GetType().Name}' is already registered!");
                return;
            }

            _registeredScreens.Add(screen);
        }

        public void UnregisterScreen(IUIScreen screen)
        {
            if (!_registeredScreens.Contains(screen))
            {
                Debug.LogWarning($"Couldn't unregister the screen '{screen.GetType().Name}' because it wasn't registered!");
                return;
            }

            _registeredScreens.Remove(screen);
        }

        public void OpenScreen<T>(bool additive = true) where T : IUIScreen
        {
            if (TryGetRegisteredScreen<T>(out IUIScreen screen))
            {
                if (_openedScreens.Contains(screen))
                {
                    Debug.LogWarning($"The screen '{typeof(T).Name}' is already opened!");
                    return;
                }

                OpenScreen(screen, additive);
            }
        }

        public void CloseScreenOnTop()
        {
            if (!_openedScreens.TryPeek(out IUIScreen screen))
            {
                Debug.LogWarning("Couldn't close screen on top because there's none!");
                return;
            }

            screen = _openedScreens.Pop();

            CloseScreen(screen);
        }

        protected override void RegisterService()
        {
            ServiceLocator.RegisterService<IScreenService>(this);
        }

        protected override void UnregisterService()
        {
            ServiceLocator.UnregisterService<IScreenService>();
        }

        private void OpenScreen(IUIScreen screen, bool additive)
        {
            if (!additive)
            {
                HideScreenOnTop();
            }

            screen.Open();

            _openedScreens.Push(screen);
        }

        private void CloseScreen(IUIScreen screen)
        {
            screen.Close();

            if (_openedScreens.TryPeek(out screen))
            {
                screen.Show();
            }
        }

        private void HideScreenOnTop()
        {
            if (_openedScreens.TryPeek(out IUIScreen screen))
            {
                screen.Hide();
            }
        }

        private bool TryGetRegisteredScreen<T>(out IUIScreen screen)
        {
            foreach (IUIScreen registeredScreen in _registeredScreens)
            {
                if (registeredScreen is T)
                {
                    screen = registeredScreen;
                    return true;
                }
            }

            Debug.LogError($"There's no registered screen named '{typeof(T).Name}'!");

            screen = null;
            return false;
        }
    }
}

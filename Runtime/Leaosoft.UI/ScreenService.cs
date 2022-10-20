using Screen = Leaosoft.UI.Screens.Screen;
using System.Collections.Generic;
using System.Collections;
using Leaosoft.Services;
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
        private readonly List<Screen> _openedScreens = new List<Screen>();
        private readonly List<Screen> _registeredScreens = new List<Screen>();
        private Screen _currentOpenedScreen;

        public Screen CurrentOpenedScreen => _currentOpenedScreen;

        public void RegisterService()
        {
            ServiceLocator.RegisterService<IScreenService>(this);
        }

        public void UnregisterService()
        {
            ServiceLocator.DeregisterService<IScreenService>();
        }
        
        public void Initialize()
        {}
        
        public Screen OpenScreen(Screen screen, OpenScreenMode openScreenMode = OpenScreenMode.Single, float delay = 0)
        {
            StartCoroutine(OpenScreenRoutine());
            
            IEnumerator OpenScreenRoutine()
            {
                yield return new WaitForSeconds(delay);
                
                if (openScreenMode == OpenScreenMode.Single)
                {
                    CloseCurrentScreen();
                }
            
                if (_openedScreens.Contains(screen))
                {
                    _openedScreens.Remove(screen);
                }
                
                _openedScreens.Add(screen);

                _currentOpenedScreen = screen;

                _currentOpenedScreen.gameObject.SetActive(true);
            }
            
            return screen;
        }
        
        public Screen OpenScreen<T>(OpenScreenMode openScreenMode = OpenScreenMode.Single, float delay = 0) where T : Screen
        {
            foreach (Screen registeredScreen in _registeredScreens)
            {
                if (registeredScreen is T)
                {
                    OpenScreen(registeredScreen, openScreenMode, delay);

                    return registeredScreen;
                }
            }

            Debug.LogWarning($"{typeof(T)} is not registered. Probably you are trying to open the screen before it be registered");
            
            return null;
        }
        
        public void CloseTopScreen()
        {
            if (_currentOpenedScreen == null)
            {
                return;
            }

            _currentOpenedScreen.Close();

            _openedScreens.Remove(_currentOpenedScreen);
                
            OpenPreviousScreen();
        }

        public void CloseAllScreens()
        {
            foreach (Screen openedScreen in _openedScreens)
            {
                openedScreen.Close();
            }
            
            _openedScreens.Clear();
        }
        
        public void RegisterScreen(Screen screen)
        {
            if (_registeredScreens.Contains(screen))
            {
                Debug.LogWarning("This screen is already registered");
                
                return;
            }
            
            _registeredScreens.Add(screen);
        }
        
        public void UnregisterScreen(Screen screen)
        {
            if (!_registeredScreens.Contains(screen))
            {
                return;
            }
            
            _registeredScreens.Remove(screen);
            _openedScreens.Remove(screen);
        }

        private void CloseCurrentScreen()
        {
            if (_openedScreens.Count <= 0)
            {
                return;
            }

            if (_currentOpenedScreen == null)
            {
                return;
            }

            _currentOpenedScreen.Close();
        }
        
        private void OpenPreviousScreen()
        {
            if (_openedScreens.Count <= 0)
            {
                return;
            }

            int lastIndex = _openedScreens.Count - 1;
            
            Screen previousScreen = _openedScreens[lastIndex];

            OpenScreen(previousScreen);
        }

        public Screen GetRegisteredScreen<T>() where T : Screen
        {
            foreach (Screen registeredScreen in _registeredScreens)
            {
                if (registeredScreen is T)
                {
                    return registeredScreen;
                }
            }

            Debug.LogWarning("You are trying to get an unregistered screen");
            
            return null;
        }
    }
}

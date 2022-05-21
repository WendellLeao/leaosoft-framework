using System.Collections.Generic;
using System.Collections;
using Game.UI.Screens;
using Game.Services;
using UnityEngine;

namespace Game.UI
{
    public sealed class UIService : MonoBehaviour, IUIService
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        
        private readonly List<UIScreen> _openedScreens = new List<UIScreen>();
        private readonly List<UIScreen> _registeredScreens = new List<UIScreen>();
        private UIScreen _currentOpenedScreen;

        public UIScreen CurrentOpenedScreen => _currentOpenedScreen;

        public UIScreen OpenScreen(UIScreen uiScreen, OpenScreenMode openScreenMode = OpenScreenMode.Single, float delay = 0)
        {
            StartCoroutine(OpenScreenRoutine());
            
            IEnumerator OpenScreenRoutine()
            {
                yield return new WaitForSeconds(delay);
                
                if (openScreenMode == OpenScreenMode.Single)
                {
                    CloseCurrentScreen();
                }
            
                if (_openedScreens.Contains(uiScreen))
                {
                    _openedScreens.Remove(uiScreen);
                }
                
                _openedScreens.Add(uiScreen);

                _currentOpenedScreen = uiScreen;

                _currentOpenedScreen.gameObject.SetActive(true);
            }
            
            return uiScreen;
        }
        
        public UIScreen OpenScreen<T>(OpenScreenMode openScreenMode = OpenScreenMode.Single, float delay = 0) where T : UIScreen
        {
            foreach (UIScreen registeredScreen in _registeredScreens)
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

        public void OpenLoadingScreen(AsyncOperation operation)
        {
            _loadingScreen.Initialize(operation);

            OpenScreen(_loadingScreen);
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
            foreach (UIScreen openedScreen in _openedScreens)
            {
                openedScreen.Close();
            }
            
            _openedScreens.Clear();
        }
        
        public void RegisterScreen(UIScreen uiScreen)
        {
            if (_registeredScreens.Contains(uiScreen))
            {
                Debug.LogWarning("This screen is already registered");
                
                return;
            }
            
            _registeredScreens.Add(uiScreen);
        }
        
        public void UnregisterScreen(UIScreen uiScreen)
        {
            if (!_registeredScreens.Contains(uiScreen))
            {
                return;
            }
            
            _registeredScreens.Remove(uiScreen);
            _openedScreens.Remove(uiScreen);
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
            
            UIScreen previousScreen = _openedScreens[lastIndex];

            OpenScreen(previousScreen);
        }

        public UIScreen GetRegisteredScreen<T>() where T : UIScreen
        {
            foreach (UIScreen registeredScreen in _registeredScreens)
            {
                if (registeredScreen is T)
                {
                    return registeredScreen;
                }
            }

            Debug.LogWarning("You are trying to get an unregistered screen");
            
            return null;
        }

        private void Awake()
        {
            ServiceLocator.RegisterService<IUIService>(this);
            
            DontDestroyOnLoad(gameObject);
        }

        private void OnDestroy()
        {
            ServiceLocator.DeregisterService<IUIService>();
        }
    }
}

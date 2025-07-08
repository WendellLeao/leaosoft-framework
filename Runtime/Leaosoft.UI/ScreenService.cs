using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Leaosoft.Services;
using Leaosoft.UI.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leaosoft.UI
{
    /// <summary>
    /// The ScreenService provides the abstraction <see cref="IScreenService"/> to open or close screens.
    /// <seealso cref="ServiceLocator"/>
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class ScreenService : GameService, IScreenService
    {
        private readonly Stack<IUIScreen> _openedScreens = new();

        public async UniTask<IUIScreen> OpenScreenAsync(UIScreenData screenData)
        {
            if (IsScreenOpened(screenData, out IUIScreen screen))
            {
                Debug.LogWarning($"The screen with id '{screen.Data.Id}' is already opened!");
                return screen;
            }
            
            IUIScreen screenOnTop = await LoadAndGetScreenAsync(screenData);

            screenOnTop.OnCloseRequested += HandleScreenCloseRequested;
            
            screenOnTop.Open();
            
            _openedScreens.Push(screenOnTop);

            return screen;
        }

        // todo: cancellation
        public async void CloseCurrentScreenOnTop()
        {
            if (!_openedScreens.TryPop(out IUIScreen screenOnTop))
            {
                Debug.LogError("There's no current screen on top!");
                return;
            }
            
            screenOnTop.OnCloseRequested -= HandleScreenCloseRequested;
            
            screenOnTop.Close();

            await SceneManager.UnloadSceneAsync(screenOnTop.Data.SceneName);
        }
        
        protected override void RegisterService()
        {
            ServiceLocator.RegisterService<IScreenService>(this);
        }

        protected override void UnregisterService()
        {
            ServiceLocator.UnregisterService<IScreenService>();
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);

            foreach (IUIScreen openedScreen in _openedScreens)
            {
                openedScreen.Tick(deltaTime);
            }
        }

        private async UniTask<IUIScreen> LoadAndGetScreenAsync(UIScreenData screenData)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(screenData.SceneName, LoadSceneMode.Additive);

            if (asyncOperation == null)
            {
                throw new NullReferenceException($"The async operation for the screen scene '{screenData.SceneName}' is null!");
            }
            
            while (!asyncOperation.isDone)
            {
                await UniTask.Yield();
            }

            await UniTask.Yield();

            Scene scene = SceneManager.GetSceneByName(screenData.SceneName);

            foreach (GameObject rootGameObject in scene.GetRootGameObjects())
            {
                if (rootGameObject.TryGetComponent(out IUIScreen screen))
                {
                    return screen;
                }
            }

            throw new ArgumentException($"Couldn't find any screen component in the scene '{scene.name}'!");
        }

        private void HandleScreenCloseRequested(IUIScreen screen)
        {
            if (!_openedScreens.TryPeek(out IUIScreen screenOnTop))
            {
                Debug.LogError("Couldn't peek the current screen on top!");
            }
            
            if (!string.Equals(screen.Data.Id, screenOnTop.Data.Id))
            {
                Debug.LogError($"The screen with id '{screen.Data.Id}' is requesting to be closed but is not the one on top!");
                return;
            }
            
            CloseCurrentScreenOnTop();
        }
        
        private bool IsScreenOpened(UIScreenData screenData, out IUIScreen screen)
        {
            foreach (IUIScreen openedScreen in _openedScreens)
            {
                if (string.Equals(openedScreen.Data.Id, screenData.Id))
                {
                    screen = openedScreen;
                    return true;
                }
            }

            screen = null;
            return false;
        }
    }
}

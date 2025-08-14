using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Leaosoft.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leaosoft.Core
{
    /// <summary>
    /// Controls the game's initialization.
    /// </summary>
    public sealed class StartupSystem : System
    {
        [SerializeField]
        private ServiceManager serviceManager;
        
        private CancellationTokenSource _loadSceneCts;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            serviceManager.Initialize();
            
            RegisterManagers(serviceManager);
            
            _loadSceneCts?.Cancel();
            _loadSceneCts = new CancellationTokenSource();
            
            InitializeAndLoadOriginalSceneRoutine(_loadSceneCts.Token).Forget();
        }
        
        private async UniTask InitializeAndLoadOriginalSceneRoutine(CancellationToken token)
        {
            try
            {
                await UniTask.NextFrame(token);

                string originalScenePathKey = PlayerPrefsUtility.OriginalScenePathKey;
                string shouldReturnToOriginalSceneKey = PlayerPrefsUtility.ShouldReturnToOriginalSceneKey;
                
                string originalScenePath = PlayerPrefs.GetString(originalScenePathKey, "");
                bool shouldReturnToOriginal = PlayerPrefs.GetInt(shouldReturnToOriginalSceneKey, 0) == 1;

                if (!shouldReturnToOriginal || string.IsNullOrEmpty(originalScenePath))
                {
                    ScenesUtility.LoadNextScene();
                    return;
                }

                PlayerPrefs.DeleteKey(originalScenePathKey);
                PlayerPrefs.DeleteKey(shouldReturnToOriginalSceneKey);

                await SceneManager.LoadSceneAsync(originalScenePath, LoadSceneMode.Single).WithCancellation(token);
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            finally
            {
                _loadSceneCts?.Dispose();
                _loadSceneCts = null;
            }
        }
    }
}

#if !UNITY_EDITOR && !DEVELOPMENT_BUILD
using UnityEngine;

namespace Leaosoft.Core
{
    public static class LogsHandler
    {
        private static bool _hasDisableLogs;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void HandleLogsVisibility()
        {
            if (_hasDisableLogs)
            {
                return;
            }
            
            ILogger logger = Debug.unityLogger;

            logger.logEnabled = false;

            _hasDisableLogs = true;
        }
    }
}
#endif

using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;
using System;

namespace Game.UI.Screens
{
    public sealed class LoadingBarController : MonoBehaviour
    {
        public event Action OnProgressBarFilled;
        
        [SerializeField] private Image _progressBar;
        [SerializeField] private float _fillDuration = 1f;
        
        private float _sceneProgress;

        public void Initialize(AsyncOperation operation)
        {
            _sceneProgress = 0f;

            _progressBar.fillAmount = 0f;
            
            StartCoroutine(GetUpdateProgressBarRoutine(operation));
        }
        
        private IEnumerator GetUpdateProgressBarRoutine(AsyncOperation operation)
        {
            while (!operation.isDone)
            {
                _sceneProgress = Mathf.Clamp01(operation.progress / 0.9f);
            
                _progressBar.DOFillAmount(_sceneProgress, _fillDuration);

                yield return null;
            }
            
            OnProgressBarFilled?.Invoke();
        }
    }
}

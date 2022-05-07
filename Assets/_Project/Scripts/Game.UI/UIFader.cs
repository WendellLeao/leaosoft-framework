// using DG.Tweening;//TODO: Uncomment this
using UnityEngine;
using System;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class UIFader : MonoBehaviour
    {
        public event Action OnFadeCompleted;
        
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeDuration = 1f;
        
        // private Tween _tween;
        
        public void Fade(float endValue)
        {
            // _tween = _canvasGroup.DOFade(endValue, _fadeDuration).OnComplete(HandleFadeComplete);//TODO: Import DOTween
        }
        
        public void SetCanvasGroupAlpha(float value)
        {
            _canvasGroup.alpha = value;
        }
        
        private void HandleFadeComplete()
        {
            OnFadeCompleted?.Invoke();
        }
        
        private void OnDestroy()
        {
            // _tween.Kill();//TODO: Uncomment this
        }
    }
}

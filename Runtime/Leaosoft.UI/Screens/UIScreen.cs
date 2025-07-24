using System;
using UnityEngine;
using UnityEngine.UI;

namespace Leaosoft.UI.Screens
{
    public abstract class UIScreen : MonoBehaviour, IUIScreen
    {
        public event Action<IUIScreen> OnCloseRequested;

        [Header("Objects")]
        [SerializeField]
        private Button closeButton;
        [SerializeField]
        private CanvasGroup canvasGroup;
        
        [Header("Data")]
        [SerializeField]
        private UIScreenData screenData;

        private bool _isOpened;
        private bool _isVisible = true;

        public UIScreenData Data => screenData;
        
        public void Open()
        {
            if (_isOpened)
            {
                return;
            }

            SetIsOpened(true);

            SubscribeEvents();

            OnOpen();
        }

        public void Close()
        {
            if (!_isOpened)
            {
                return;
            }

            SetIsOpened(false);

            UnsubscribeEvents();

            OnClose();
        }

        public void Tick(float deltaTime)
        {
            if (!_isOpened || !_isVisible)
            {
                return;
            }

            OnTick(deltaTime);
        }

        public void Show()
        {
            if (_isVisible)
            {
                return;
            }
            
            canvasGroup.alpha = 1f;

            SetIsVisible(true);
            
            OnShow();
        }

        public void Hide()
        {
            if (!_isVisible)
            {
                return;
            }
            
            canvasGroup.alpha = 0f;
            
            SetIsVisible(false);
            
            OnHide();
        }
        
        protected virtual void OnSubscribeEvents()
        { }

        protected virtual void OnUnsubscribeEvents()
        { }

        protected virtual void OnOpen()
        { }

        protected virtual void OnClose()
        { }

        protected virtual void OnTick(float deltaTime)
        { }
        
        protected virtual void OnShow()
        { }

        protected virtual void OnHide()
        { }

        private void SubscribeEvents()
        {
            if (closeButton)
            {
                closeButton.onClick.AddListener(HandleCloseButtonClick);
            }

            OnSubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            if (closeButton)
            {
                closeButton.onClick.RemoveListener(HandleCloseButtonClick);
            }

            OnUnsubscribeEvents();
        }

        private void HandleCloseButtonClick()
        {
            OnCloseRequested?.Invoke(this);
        }
        
        private void SetIsOpened(bool isOpened)
        {
            _isOpened = isOpened;
        }

        private void SetIsVisible(bool isVisible)
        {
            _isVisible = isVisible;
        }
    }
}

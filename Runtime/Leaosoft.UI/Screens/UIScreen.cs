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
        
        [Header("Data")]
        [SerializeField]
        private UIScreenData screenData;

        private bool _isOpened;

        public UIScreenData Data => screenData;
        
        public void Open()
        {
            if (_isOpened)
            {
                return;
            }

            SetIsOpened(true);

            SetActive(true);
            
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

            SetActive(false);
            
            UnsubscribeEvents();

            OnClose();
        }

        public void Tick(float deltaTime)
        {
            if (!_isOpened)
            {
                return;
            }

            OnTick(deltaTime);
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

        private void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}

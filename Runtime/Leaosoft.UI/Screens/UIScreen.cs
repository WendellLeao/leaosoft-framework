using System;
using UnityEngine;
using UnityEngine.UI;

namespace Leaosoft.UI.Screens
{
    public abstract class UIScreen : MonoBehaviour, IUIScreen
    {
        public event Action<IUIScreen> OnOpened;
        public event Action<IUIScreen> OnClosed;

        [Header("Objects")]
        [SerializeField]
        private Button closeButton;
        
        [Header("Data")]
        [SerializeField]
        private UIScreenData screenData;

        private bool _isOpened;
        private bool _isHidden;

        public string Id => screenData.Id;

        public void Open()
        {
            if (_isOpened)
            {
                return;
            }

            SetIsOpened(true);

            SubscribeEvents();

            OnOpen();

            OnOpened?.Invoke(this);
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

            OnClosed?.Invoke(this);
        }

        public void Show()
        {
            if (!_isOpened || !_isHidden)
            {
                return;
            }

            SetIsHidden(false);

            OnShow();
        }

        public void Hide()
        {
            if (!_isOpened || _isHidden)
            {
                return;
            }

            SetIsHidden(true);

            OnHide();
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

        protected virtual void OnShow()
        { }

        protected virtual void OnHide()
        { }

        protected virtual void OnTick(float deltaTime)
        { }

        protected virtual void OnCloseButtonClick()
        {
            Close();
        }

        private void SubscribeEvents()
        {
            if (closeButton is not null)
            {
                closeButton.onClick.AddListener(OnCloseButtonClick);
            }

            OnSubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            if (closeButton is not null)
            {
                closeButton.onClick.RemoveListener(OnCloseButtonClick);
            }

            OnUnsubscribeEvents();
        }

        private void SetIsOpened(bool isOpened)
        {
            _isOpened = isOpened;

            SetActive(_isOpened);
        }

        private void SetIsHidden(bool isHidden)
        {
            _isHidden = isHidden;

            SetActive(!_isHidden);
        }

        private void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}

using Game.Services;
using UnityEngine;
using System;

namespace Game.UI.Screens
{
    public abstract class UIScreen : MonoBehaviour
    {
        public event Action<UIScreen> OnClosed;
        
        private IUIService _uiService;
        private bool _isOpen;

        public bool IsOpen => _isOpen;
        protected IUIService UIService => _uiService;

        public void Close()
        {
            _isOpen = false;
            
            UnsubscribeEvents();
            
            OnClose();
        }

        protected virtual void SubscribeEvents()
        {}
        
        protected virtual void UnsubscribeEvents()
        {}

        protected virtual void OnInitialize()
        {}
        
        protected virtual void OnOpen()
        {}

        protected virtual void OnClose()
        {
            gameObject.SetActive(false);

            DispatchClosedEvent();
        }
        
        protected virtual void OnDestroy()
        {
            _uiService.UnregisterScreen(this);
        }

        protected void DispatchClosedEvent()
        {
            OnClosed?.Invoke(this);
        }
        
        private void Awake()
        {
            _uiService = ServiceLocator.GetService<IUIService>();
            
            _uiService.RegisterScreen(this);
            
            gameObject.SetActive(false);
            
            OnInitialize();
        }

        private void OnEnable()
        {
            SubscribeEvents();
            
            OnOpen();

            _isOpen = true;
        }
    }
}

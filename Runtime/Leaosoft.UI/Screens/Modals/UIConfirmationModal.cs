using System;
using UnityEngine;

namespace Leaosoft.UI.Screens.Modals
{
    public sealed class UIConfirmationModal : UIModalScreen
    {
        public event Action OnModalConfirmed;

        [Header("Confirmation Settings")]
        [SerializeField]
        private UIScreenButton _confirmButton;
        [SerializeField]
        private UIScreenButton _denyButton;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _confirmButton.Initialize();
            _denyButton.Initialize();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _confirmButton.Dispose();
            _denyButton.Dispose();
        }

        protected override void OnSubscribeEvents()
        {
            base.OnSubscribeEvents();

            _confirmButton.OnClick += HandleConfirmButtonClick;
            _denyButton.OnClick += OnCloseButtonClick;
        }

        protected override void OnUnsubscribeEvents()
        {
            base.OnUnsubscribeEvents();

            _confirmButton.OnClick -= HandleConfirmButtonClick;
            _denyButton.OnClick -= OnCloseButtonClick;
        }

        private void HandleConfirmButtonClick()
        {
            OnModalConfirmed?.Invoke();

            Close();
        }
    }
}

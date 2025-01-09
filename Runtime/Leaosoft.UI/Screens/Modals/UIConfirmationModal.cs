using System;
using UnityEngine;

namespace Leaosoft.UI.Screens.Modals
{
    public sealed class UIConfirmationModal : UIModalScreen
    {
        public event Action OnModalConfirmed;

        [Header("Confirmation Settings")]
        [SerializeField]
        private UIScreenButton confirmButton;
        [SerializeField]
        private UIScreenButton denyButton;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            confirmButton.Initialize();
            denyButton.Initialize();
        }

        protected override void OnDispose()
        {
            base.OnDispose();

            confirmButton.Dispose();
            denyButton.Dispose();
        }

        protected override void OnSubscribeEvents()
        {
            base.OnSubscribeEvents();

            confirmButton.OnClick += HandleConfirmButtonClick;
            denyButton.OnClick += OnCloseButtonClick;
        }

        protected override void OnUnsubscribeEvents()
        {
            base.OnUnsubscribeEvents();

            confirmButton.OnClick -= HandleConfirmButtonClick;
            denyButton.OnClick -= OnCloseButtonClick;
        }

        private void HandleConfirmButtonClick()
        {
            OnModalConfirmed?.Invoke();

            Close();
        }
    }
}

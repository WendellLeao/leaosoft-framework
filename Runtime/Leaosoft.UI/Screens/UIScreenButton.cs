using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Leaosoft.UI.Screens
{
    public abstract class UIScreenButton : MonoBehaviour
    {
        public event Action OnClick;

        [Header("Button Settings")]
        [SerializeField]
        private Button button;

        [Header("Animation Settings")]
        [SerializeField]
        private float delayDispatchClick = 0.08f;

        public void Initialize()
        {
            button.onClick.AddListener(HandleButtonClick);

            OnInitialize();
        }

        public void Dispose()
        {
            button.onClick.RemoveListener(HandleButtonClick);

            OnDispose();
        }

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDispose()
        { }

        private void HandleButtonClick()
        {
            DispatchClickEventAsync();
        }

        private async void DispatchClickEventAsync()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(delayDispatchClick));

            OnClick?.Invoke();
        }

        public void SetIsInteractable(bool isInteractable)
        {
            button.interactable = isInteractable;
        }

        public void SetSprite(Sprite sprite)
        {
            button.image.sprite = sprite;
        }
    }
}

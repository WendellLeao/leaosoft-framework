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
        private Button _button;

        [Header("Animation Settings")]
        [SerializeField]
        private float _delayDispatchClick = 0.08f;

        public void Initialize()
        {
            _button.onClick.AddListener(HandleButtonClick);

            OnInitialize();
        }

        public void Dispose()
        {
            _button.onClick.RemoveListener(HandleButtonClick);

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
            await UniTask.Delay(TimeSpan.FromSeconds(_delayDispatchClick));

            OnClick?.Invoke();
        }

        public void SetIsInteractable(bool isInteractable)
        {
            _button.interactable = isInteractable;
        }

        public void SetSprite(Sprite sprite)
        {
            _button.image.sprite = sprite;
        }
    }
}

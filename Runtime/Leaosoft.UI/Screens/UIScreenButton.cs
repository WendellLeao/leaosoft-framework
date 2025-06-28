using Cysharp.Threading.Tasks;
using System;
using System.Threading;
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

        private CancellationTokenSource _dispatchClickEventCts;
        
        public void Initialize()
        {
            button.onClick.AddListener(HandleButtonClick);

            OnInitialize();
        }

        public void Dispose()
        {
            button.onClick.RemoveListener(HandleButtonClick);

            DisposeDispatchClickEventCts();
            
            OnDispose();
        }

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDispose()
        { }

        private void HandleButtonClick()
        {
            _dispatchClickEventCts?.Cancel();
            _dispatchClickEventCts = new CancellationTokenSource();
            
            DispatchClickEventAsync(_dispatchClickEventCts.Token);
        }

        private async void DispatchClickEventAsync(CancellationToken token)
        {
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(delayDispatchClick), cancellationToken: token);

                OnClick?.Invoke();
            }
            catch (OperationCanceledException e)
            { }
            catch (Exception e)
            {
                Debug.LogError(e, gameObject);
            }
            finally
            {
                DisposeDispatchClickEventCts();
            }
        }

        private void DisposeDispatchClickEventCts()
        {
            _dispatchClickEventCts?.Cancel();
            _dispatchClickEventCts?.Dispose();
            _dispatchClickEventCts = null;
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

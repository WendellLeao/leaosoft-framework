using UnityEngine;

namespace Game.UI.Screens
{
    public sealed class LoadingScreen : UIScreen
    {
        [Header("Fade")] 
        [SerializeField] private UIFader _uiFader;

        [Header("Loading Bar")] 
        [SerializeField] private LoadingBarController _loadingBarController;

        protected override void OnOpen()
        {
            base.OnOpen();
            
            _uiFader.SetCanvasGroupAlpha(1f);

            _loadingBarController.Initialize(null);//TODO: Pass the operation
        }

        protected override void OnClose()
        {
            float endValue = 0f;
            
            _uiFader.Fade(endValue);

            _uiFader.OnFadeCompleted += HandleFadeCompleted;
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();

            _loadingBarController.OnOperationCompleted += UIService.CloseTopScreen;
        }

        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            
            _loadingBarController.OnOperationCompleted -= UIService.CloseTopScreen;
        }

        private void HandleFadeCompleted()
        {
            gameObject.SetActive(false);
            
            DispatchClosedEvent();
            
            _uiFader.OnFadeCompleted -= HandleFadeCompleted;
        }
    }
}

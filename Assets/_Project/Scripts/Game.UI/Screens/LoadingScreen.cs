using UnityEngine;

namespace Game.UI.Screens
{
    public sealed class LoadingScreen : UIScreen
    {
        [Header("Fade")] 
        [SerializeField] private UIFader _uiFader;

        [Header("Loading Bar")] 
        [SerializeField] private LoadingBarController _loadingBarController;

        private AsyncOperation _operation;

        public void Initialize(AsyncOperation operation)
        {
            _operation = operation;
        }
        
        protected override void OnOpen()
        {
            base.OnOpen();
            
            _uiFader.SetCanvasGroupAlpha(1f);

            _loadingBarController.Initialize(_operation);
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
            
            _loadingBarController.OnProgressBarFilled += UIService.CloseTopScreen;
        }

        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            
            _loadingBarController.OnProgressBarFilled -= UIService.CloseTopScreen;
        }
        
        private void HandleFadeCompleted()
        {
            gameObject.SetActive(false);
            
            DispatchClosedEvent();

            _uiFader.OnFadeCompleted -= HandleFadeCompleted;
        }
    }
}

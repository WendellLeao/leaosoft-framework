using Leaosoft.UI;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class ScreenServiceManager : Manager
    {
        [SerializeField] private ScreenService _screenService;
        
        protected override void OnInitialize()
        {
            base.OnInitialize();

            InitializeScreenService();
        }
        
        private void InitializeScreenService()
        {
            ScreenService screenServiceClone = Instantiate(_screenService);
            
            screenServiceClone.RegisterService();
        }
    }
}
using Leaosoft.UI.Screens;
using UnityEngine;

namespace Leaosoft.UI
{
    public sealed class ScreensManager : Manager
    {
        [SerializeField]
        private UIScreen[] _screens;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach (UIScreen screen in _screens)
            {
                screen.Initialize();
            }
        }

        protected override void OnDispose()
        {
            base.OnDispose();

            foreach (UIScreen screen in _screens)
            {
                screen.Dispose();
            }
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);

            foreach (UIScreen screen in _screens)
            {
                screen.Tick(deltaTime);
            }
        }
    }
}

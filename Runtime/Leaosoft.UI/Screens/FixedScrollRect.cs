using UnityEngine;
using UnityEngine.UI;

namespace Leaosoft.UI.Screens
{
    public sealed class FixedScrollRect : ScrollRect
    {
        [SerializeField]
        private float fixedSide = 0.125f;

        protected override void LateUpdate()
        {
            base.LateUpdate();

            TrySetHorizontalScrollbarSize(fixedSide);
            TrySetVerticalScrollbarSize(fixedSide);
        }

        public override void Rebuild(CanvasUpdate executing)
        {
            base.Rebuild(executing);

            TrySetHorizontalScrollbarSize(fixedSide);
            TrySetVerticalScrollbarSize(fixedSide);
        }

        private void TrySetHorizontalScrollbarSize(float size)
        {
            if (horizontalScrollbar is not null)
            {
                horizontalScrollbar.size = size;
            }
        }

        private void TrySetVerticalScrollbarSize(float size)
        {
            if (verticalScrollbar is not null)
            {
                verticalScrollbar.size = size;
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Leaosoft.UI.Screens
{
    public sealed class FixedScrollRect : ScrollRect
    {
        [SerializeField]
        private float _fixedSide = 0.125f;

        protected override void LateUpdate()
        {
            base.LateUpdate();

            TrySetHorizontalScrollbarSize(_fixedSide);
            TrySetVerticalScrollbarSize(_fixedSide);
        }

        public override void Rebuild(CanvasUpdate executing)
        {
            base.Rebuild(executing);

            TrySetHorizontalScrollbarSize(_fixedSide);
            TrySetVerticalScrollbarSize(_fixedSide);
        }

        private void TrySetHorizontalScrollbarSize(float size)
        {
            if (horizontalScrollbar != null)
            {
                horizontalScrollbar.size = size;
            }
        }

        private void TrySetVerticalScrollbarSize(float size)
        {
            if (verticalScrollbar != null)
            {
                verticalScrollbar.size = size;
            }
        }
    }
}

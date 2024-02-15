using UnityEngine;

namespace Leaosoft.Utilities.Extensions
{
    public static class TransformExtensions
    {
        public static void ResetTransform(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static string GetRootName(this Transform transform)
        {
            Transform root = transform.root;

            return root.name;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Leaosoft.Utilities.Extensions
{
    public static class ListExtensions
    {
        public static bool TryGetFirst<T>(this List<T> list, out T item)
        {
            if (list.Count <= 0)
            {
                item = default;
                return false;
            }

            item = list[0];
            return true;
        }

        public static bool TryGetLast<T>(this List<T> list, out T item)
        {
            if (list.Count <= 0)
            {
                item = default;
                return false;
            }

            int lastIndex = list.Count - 1;
            int clampedLastIndex = Math.Clamp(lastIndex, 0, lastIndex);

            item = list[clampedLastIndex];
            return true;
        }
    }
}

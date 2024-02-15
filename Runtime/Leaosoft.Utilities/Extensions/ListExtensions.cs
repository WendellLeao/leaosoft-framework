using System.Collections.Generic;

namespace Leaosoft.Utilities.Extensions
{
    public static class ListExtensions
    {
        public static T First<T>(this List<T> list)
        {
            int firstIndex = 0;
            
            return list[firstIndex];
        }
        
        public static T Last<T>(this List<T> list)
        {
            int lastIndex = list.Count - 1;
            
            return list[lastIndex];
        }
    }
}

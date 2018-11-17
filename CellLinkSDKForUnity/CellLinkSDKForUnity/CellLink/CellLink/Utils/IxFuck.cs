using System;

namespace CellLink
{
    public class IxFuck
    {
        public static bool IsIsAssignableFrom(Type typeParent, Type typeChild)
        {
            if (typeParent == null || typeChild == null )
            {
                return false;
            }

            return typeParent.IsAssignableFrom(typeChild);            
        }
    }
}

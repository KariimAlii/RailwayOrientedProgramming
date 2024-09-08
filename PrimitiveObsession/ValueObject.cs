using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveObsession
{
    public abstract class ValueObject<T> 
         where T : ValueObject<T>
    {
        public override bool Equals(object? obj)
        {
            // 🚩🚩Check for Type
            var valueObject = obj as T;

            // 🚩🚩Check for null
            if (ReferenceEquals(valueObject, null))
                return false;

            return EqualsCore(valueObject);
        }
        public abstract bool EqualsCore(T valueObject); // 🚩🚩Every child should provide its own implementation

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }
        public abstract int GetHashCodeCore();  // 🚩🚩Every child should provide its own implementation
        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b); 
        }
    }
   
}

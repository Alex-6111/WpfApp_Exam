using System.Collections;
using System.Collections.Generic;

namespace WpfApp_Exam
{
 
    public sealed class Multiple<T> : CanError, IEnumerable<T> where T : class
    {
        internal Multiple() { }

  
        public Info Info { get; set; }

 
        public T[] Results { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in Results)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index] {
            get {
                return Results[index];
            }

            set {
                Results[index] = value;
            }
        }
    }
}
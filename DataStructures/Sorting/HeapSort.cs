using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures.Sorting
{
    public class HeapSort<TInput> : ISort<TInput>
    {
        private readonly TInput[] _inputs;
        private readonly IComparer<TInput> _comparer;

        public HeapSort(IEnumerable<TInput> inputs)
            : this(inputs, Comparer<TInput>.Default)
        {           
        }

        public HeapSort(IEnumerable<TInput> inputs, IComparer<TInput> comparer)            
        {
            if (inputs is null)
            {
                throw new ArgumentNullException(nameof(inputs));
            }

            _comparer = comparer;
            _inputs = inputs.ToArray();
        }   

        public TInput[] Sort()
        {
            return new Heap<TInput>(_inputs).Sort();
        }

        /// <summary>
        /// Returns a new array that has been heap sorted.
        /// </summary>
        /// <param name="items"><see cref="IEnumerable&lt;TValue&gt;"/>&lt;<typeparamref name="TInput"/>&gt; of items to sort.</param>
        /// <returns>A new <typeparamref name="TInput"/>[] that has been heap sorted.</returns>
        public static TInput[] Sort(IEnumerable<TInput> items)
        {
            return new HeapSort<TInput>(items).Sort();
        }

        /// <summary>
        /// Returns a new array that has been heap sorted using the specified IComparer.
        /// </summary>
        /// <param name="items"><see cref="IEnumerable&lt;TValue&gt;"/>&lt;<typeparamref name="TInput"/>&gt; of items to sort.</param>        
        /// <param name="comparer">IComparer&lt;<typeparamref name="TInput"/>&gt; to compare items when sorting.</param>
        /// <returns>A new <typeparamref name="TInput"/>[] that has been heap sorted.</returns>
        public static TInput[] Sort(IEnumerable<TInput> items, IComparer<TInput> comparer)
        {
            return new HeapSort<TInput>(items, comparer).Sort();
        }      
    }
}

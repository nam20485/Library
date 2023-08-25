using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Library.Tests
{
    public abstract class IDsCollectionsTestData<TInput> : IEnumerable<object[]>
    {
        protected abstract TInput[][] Inputs { get; }
       
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var inputs in Inputs)
            {
                yield return new object[] { new DataStructures.List<TInput>(), inputs };
                yield return new object[] { new DataStructures.LinkedList<TInput>(), inputs };
                yield return new object[] { new DataStructures.Heap<TInput>(), inputs };
                yield return new object[] { new DataStructures.MinHeap<TInput>(), inputs };
                yield return new object[] { new DataStructures.Queue<TInput>(), inputs };
                //yield return new object[] { new DataStructures.Stack<TInput>(), inputs };

                //yield return new object[] { new DataStructures.PriorityQueue<TInput, TInput>(), inputs };
                //yield return new object[] { new DataStructures.MinPriorityQueue<TInput, TInput>(), inputs };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

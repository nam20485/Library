using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Library.Tests
{
    public abstract class IDsCollectionsTestData<TInput> : IEnumerable<object[]>
    {
        protected abstract TInput[][] Inputs { get; }

        //protected IDsCollection<TInput>[] IDsCollections => 
        //    new IDsCollection<TInput>[]
        //        {                    
        //            new DataStructures.List<TInput>(),                    
        //            new DataStructures.LinkedList<TInput>(),
        //            new Heap<TInput>(),
        //        };        

        public IEnumerator<object[]> GetEnumerator()
        {
            //foreach (var iDsCollection in IDsCollections)
            //{
            //    foreach (var inputs in Inputs)
            //    {
            //        yield return new object[] { iDsCollection, inputs };
            //    }
            //}
            foreach (var inputs in Inputs)
            {
                yield return new object[] { new DataStructures.List<TInput>(), inputs };
                yield return new object[] { new DataStructures.LinkedList<TInput>(), inputs };
                yield return new object[] { new DataStructures.Heap<TInput>(), inputs };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

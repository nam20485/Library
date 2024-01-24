using Library.Utils;

namespace Library.DataStructures
{
    public class IDsCollectionOperations : Operations<IDsCollectionOperations.Type>
    {
        public enum Type
        {
            Clear,
            Add,
            AddRange,
            Contains,
            IsEmpty,

            ToString,

            CopyTo,
            CopyOf,

            ToArray,
            ToList,
            ToHeap,
            ToMinHeap,
            ToQueue,
            ToStack,

            ToArrayOfT,
            ToListOfT,
            ToHeapOfT,
            ToMinHeapOfT,
            ToQueueOfT,
            ToStackOfT,
        }
    }
}

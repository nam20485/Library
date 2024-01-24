namespace Library.DataStructures
{
    public class MinHeap<TValue> : Heap<TValue>
    {
        public MinHeap()
            : base(ReverseDefaultComparer<TValue>.Instance)
        {
        }

        public MinHeap(IEnumerable<TValue> collection)
            : base(collection, ReverseDefaultComparer<TValue>.Instance)
        { 
        }
    }
}

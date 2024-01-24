namespace Library.DataStructures
{
    public static class IDsCollectionExtensions
    {     
        public static TSource[] ToArray<TSource>(this IDsCollection<TSource> source)
        {
            return source.ToArray();
        }

        public static List<TSource> ToList<TSource>(this IDsCollection<TSource> source)
        {
            return source.ToList();            
        }

        public static Heap<TSource> ToHeap<TSource>(this IDsCollection<TSource> source)
        {
            return source.ToHeap();
        }

        public static Heap<TSource> ToHeap<TSource>(this IDsCollection<TSource> source, IComparer<TSource> comparer)
        {
            return source.ToHeap(comparer);
        }

        public static MinHeap<TSource> ToMinHeap<TSource>(this IDsCollection<TSource> source)
        {
            return source.ToMinHeap();
        }

        public static Queue<TSource> ToQueue<TSource>(this IDsCollection<TSource> source)
        {
            return source.ToQueue();
        }

        public static Stack<TSource> ToStack<TSource>(this IDsCollection<TSource> source)
        {
            return source.ToStack();
        }
    }
}

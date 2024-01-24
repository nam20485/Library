namespace Library.DataStructures
{
    public class MinPriorityQueue<TValue, TKey> : PriorityQueue<TValue, TKey>
    {
        public MinPriorityQueue()
            : base(ReverseDefaultComparer<Node>.Instance)
        {
        }
       
        public MinPriorityQueue(IEnumerable<Node> collection)
            : base(collection, ReverseDefaultComparer<Node>.Instance)
        {
        }
    }
}

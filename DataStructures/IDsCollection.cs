namespace Library.DataStructures
{
    public interface IDsCollection<TValue> : IEnumerable<TValue>
    {
        int Count { get; }

        void Add(TValue item);
        bool Contains(TValue item);
        void Clear();

        void AddRange(IEnumerable<TValue> collection);
        void CopyTo(TValue[] array, int arrayIndex = 0);
        bool IsEmpty();

        TValue[] ToArray();
        List<TValue> ToList();

        IDsCollection<TValue> CopyOf();
    }
}

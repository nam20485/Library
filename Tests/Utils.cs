using Library.DataStructures;

namespace Library.Tests
{
    internal class Utils
    {
        public static IEnumerable<IDsCollection<TInput>> MakeIDsCollections<TInput>(TInput[] inputs)
        {
            return new IDsCollection<TInput>[]
            {
                new DataStructures.List<TInput>(inputs),
                new DataStructures.LinkedList<TInput>(inputs),
                new DataStructures.Heap<TInput>(inputs)
            };
        }
    }
}

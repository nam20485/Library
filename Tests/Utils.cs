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
                new DataStructures.Heap<TInput>(inputs),
                new DataStructures.MinHeap<TInput>(inputs),
                new DataStructures.Stack<TInput>(inputs),
                new DataStructures.Queue<TInput>(inputs)                
            };
        }
    
        public static DataStructures.List<TValue> MakeList<TValue>(TValue[] inputs)
        {
            var list = new DataStructures.List<TValue>(inputs);
            list.Should().NotBeNull();
            if (inputs.Length > 0)
            {
                list.Should().NotBeEmpty();
            }
            list.Should().HaveCount(inputs.Length);
            list.Should().Contain(inputs);
            list.Should().BeEquivalentTo(inputs);
            return list;
        }
    }
}

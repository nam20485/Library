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

        public static DataStructures.List<int> MakeList(int[] inputs)
        {
            var list = new DataStructures.List<int>(inputs);
            list.Should().NotBeNull();
            list.Should().NotBeEmpty();
            list.Should().HaveCount(inputs.Length);
            return list;
        }
    }
}

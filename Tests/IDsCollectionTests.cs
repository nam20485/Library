using System.Collections;

using Library.DataStructures;

namespace Library.Tests
{
    public class IDsCollectionTests
    {       
        [Theory]
        //[MemberData(nameof(Data))]
        [ClassData(typeof(IntIDsCollectionTestData))]
        public void TestIdsCollection(IDsCollection<int> collection, int[] inputs)
        {
            Console.WriteLine($"Original: {collection}");

            collection.Should().NotBeNull();
            collection.Should().BeEmpty();

            // AddRange()           
            collection.AddRange(inputs);
            Console.WriteLine($"Inputs Added: {collection}");
            if (inputs.Length > 0)
            {
                collection.Should().NotBeEmpty();
            }
            collection.Should().Contain(inputs);            

            // ToArray()
            var a = collection.ToArray();
            a.Should().NotBeNull();
            if (inputs.Length > 0)
            {
                a.Should().NotBeEmpty();
            }
            a.Should().Contain(inputs);
            a.Should().BeEquivalentTo(inputs);

            // ToList()
            var l = collection.ToList();
            l.Should().NotBeNull();
            if (inputs.Length > 0)
            {
                l.Should().NotBeEmpty();
            }
            l.Should().Contain(inputs);
            l.Should().BeEquivalentTo(inputs);

            // Contains()
            var containsCopy = collection.CopyOf();
            foreach (var input in inputs)
            {
                containsCopy.Should().Contain(input);                
            }
            containsCopy.Clear();
            containsCopy.IsEmpty().Should().BeTrue();
            //containsCopy.Should().BeEmpty();
            //foreach (var input in inputs)
            //{
            //    containsCopy.Should().NotContain(input);
            //}

            //// Remove()
            //var removeCopy = collection;
            //var expectedSize = removeCopy.Count;
            //while (!removeCopy.IsEmpty())
            //{                
            //    removeCopy.Remove();
            //    expectedSize--;
            //    removeCopy.Should().HaveCount(expectedSize);
            //    removeCopy.Count.Should().Be(expectedSize);
            //}

            // Add()
            var addCopy = collection.CopyOf();
            addCopy.Clear();
            //addCopy.Should().BeEmpty();

            var expectedSize = 0;
            foreach (var input in inputs)
            {
                expectedSize++;
                addCopy.Add(input);
                addCopy.Should().HaveCount(expectedSize);
                addCopy.Count.Should().Be(expectedSize);
                addCopy.Should().HaveCount(addCopy.Count);
            }

            // IsEmpty()
            var isEmptyCopy = collection.CopyOf();
            isEmptyCopy.Should().NotBeEmpty();
            isEmptyCopy.IsEmpty().Should().BeFalse();
            isEmptyCopy.Clear();
            isEmptyCopy.Should().BeEmpty();
            isEmptyCopy.IsEmpty().Should().BeTrue();           

            // Clear()
            var clearCopy = collection.CopyOf();
            clearCopy.Count.Should().Be(inputs.Length);
            clearCopy.Should().NotBeEmpty();
            clearCopy.Clear();
            clearCopy.Should().BeEmpty();
            clearCopy.Count.Should().Be(0);
            //clearCopy.Should().NotContain(inputs);
        }

        public static IEnumerable<object[]> Data =>
            new object[][]
                {
                    new object[] { new Heap<int>(), new int[] { 1, 2, 3 } },
                };
    }

    public class IntIDsCollectionTestData : IDsCollectionTestDataBase<int>
    {
        protected override int[][] Inputs => new int[][]
            {
                new [] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 },
                //Array.Empty<int>(),
                //new [] { 0 },
                //new [] { 0, 1 },
                //new [] { 0, 1, 2 },
                //new [] { 0, 1, 2, 3 }
            };
    }

    public abstract class IDsCollectionTestDataBase<TInput> : IEnumerable<object[]>
    {
        protected abstract TInput[][] Inputs { get; }

        protected IDsCollection<TInput>[] IDsCollections => 
            new IDsCollection<TInput>[]
                {                    
                    new DataStructures.List<TInput>(),                    
                    //new DataStructures.LinkedList<TInput>(),
                    //new Heap<TInput>(),
                };        

        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var iDsCollection in IDsCollections)
            {
                foreach (var inputs in Inputs)
                {
                    yield return new object[] { iDsCollection, inputs };
                }
            }           
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

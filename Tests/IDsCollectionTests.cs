using Library.DataStructures;
using Library.Utils;

namespace Library.Tests
{
    public class IDsCollectionTests
    {
        [Theory]
        //[MemberData(nameof(Data))]
        //[ClassData(typeof(IntIDsCollectionTestData))]
        [ClassData(typeof(RandomIntIDsCollectionTestData))]
        public void Test_IdsCollectionOperations(IDsCollection<int> collection, int[] inputs)
        {
            //Console.WriteLine($"Original: {collection}");

            collection.Should().NotBeNull();
            collection.Should().BeEmpty();

            // set up collection 
            collection.AddRange(inputs);
            //Console.WriteLine($"Inputs Added: {collection}");
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
                containsCopy.Contains(input).Should().BeTrue();
            }
            containsCopy.Clear();
            containsCopy.IsEmpty().Should().BeTrue();
            //containsCopy.Should().BeEmpty();
            foreach (var input in inputs)
            {
                containsCopy.Contains(input).Should().BeFalse();
            }

            // Add()
            var addCopy = collection.CopyOf();
            addCopy.Clear();
            //addCopy.Should().BeEmpty();
            addCopy.IsEmpty().Should().BeTrue();
            addCopy.Count.Should().Be(0);
            foreach (var input in inputs)
            {
                addCopy.Contains(input).Should().BeFalse();
            }
            var expectedSize = 0;
            foreach (var input in inputs)
            {
                expectedSize++;
                addCopy.Add(input);
                addCopy.Contains(input).Should().BeTrue();
                //addCopy.Should().HaveCount(expectedSize);
                addCopy.Count.Should().Be(expectedSize);
                //addCopy.Should().HaveCount(addCopy.Count);
            }

            // AddRange()
            var addRangeCopy = collection.CopyOf();
            addRangeCopy.Clear();
            //addRangeCopy.Should().BeEmpty();
            addRangeCopy.IsEmpty().Should().BeTrue();
            addRangeCopy.Count.Should().Be(0);
            foreach (var input in inputs)
            {
                addRangeCopy.Contains(input).Should().BeFalse();
            }
            addRangeCopy.AddRange(inputs);
            addRangeCopy.Count.Should().Be(inputs.Length);
            foreach (var input in inputs)
            {
                addRangeCopy.Contains(input).Should().BeTrue();
            }

            // IsEmpty()
            var isEmptyCopy = collection.CopyOf();
            isEmptyCopy.Should().NotBeEmpty();
            isEmptyCopy.IsEmpty().Should().BeFalse();
            isEmptyCopy.Count.Should().Be(inputs.Length);
            isEmptyCopy.Clear();
            //isEmptyCopy.Should().BeEmpty();
            isEmptyCopy.IsEmpty().Should().BeTrue();
            isEmptyCopy.Count.Should().Be(0);

            // Clear()
            var clearCopy = collection.CopyOf();
            clearCopy.Count.Should().Be(inputs.Length);
            clearCopy.Should().NotBeEmpty();
            clearCopy.Clear();
            //clearCopy.Should().BeEmpty();
            clearCopy.IsEmpty().Should().BeTrue();
            clearCopy.Count.Should().Be(0);
            //clearCopy.Should().NotContain(inputs);
        }

        //public static IEnumerable<object[]> Data =>
        //    new object[][]
        //        {
        //            new object[] { new Heap<int>(), new int[] { 1, 2, 3 } },
        //        };

        [Fact]
        public void ConstructionWithNullCollectionThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new DataStructures.List<int>((IEnumerable<int>)null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                new DataStructures.LinkedList<int>((IEnumerable<int>)null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                new DataStructures.Heap<int>((IEnumerable<int>)null);
            });
        }
       
        [Theory]
        //[MemberData(nameof(Data))]
        //[ClassData(typeof(IntIDsCollectionTestData))]
        [ClassData(typeof(RandomIntIDsCollectionTestData))]
        public void Test_IdsCollectionRandomOperations(IDsCollection<int> collection, int[] inputs)
        {
             // used by some of the operations to get a random value from the inputs[]
            var random = new Random();

            var iterationCount = 10_000;
            while (iterationCount-- > 0)
            {
                switch (IDsCollectionOperations.NextType())
                {
                    case IDsCollectionOperations.Type.Clear:
                        {
                            collection.Clear();
                            collection.IsEmpty().Should().BeTrue();
                            collection.Count.Should().Be(0);
                            break;
                        }
                    case IDsCollectionOperations.Type.Add:
                        {
                            var prevCount = collection.Count;
                            var input = RandomInput();
                            collection.Add(input);
                            collection.Count.Should().Be(prevCount + 1);
                            collection.Contains(input).Should().BeTrue();
                            break;
                        }
                    case IDsCollectionOperations.Type.Contains:
                        {
                            foreach (var item in collection)
                            {
                                collection.Contains(item).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.IsEmpty:
                        {
                            collection.IsEmpty().Should().Be(collection.Count == 0);
                            collection.Add(RandomInput());
                            collection.IsEmpty().Should().BeFalse();
                            break;
                        }
                    case IDsCollectionOperations.Type.AddRange:
                        {
                            collection.AddRange(inputs);
                            foreach (var input in inputs)
                            {
                                collection.Contains(input).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToString:
                        {
                            if (collection.Count > 0)
                            {
                                collection.ToString().Should().NotBeNullOrWhiteSpace();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.CopyOf:
                        {
                            var copy = collection.CopyOf();
                            copy.Count.Should().Be(collection.Count);
                            foreach (var item in collection)
                            {
                                copy.Contains(item).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.CopyTo:
                        {
                            var array = new int[collection.Count];
                            collection.CopyTo(array);
                            array.Length.Should().Be(collection.Count);
                            foreach (var n in array)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToArray:
                        {
                            var array = collection.ToArray();
                            array.Length.Should().Be(collection.Count);
                            foreach (var n in array)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToArrayOfT:
                        {
                            var array = collection.ToArray<int>();
                            array.Length.Should().Be(collection.Count);
                            foreach (var n in array)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToList:
                        {
                            var list = collection.ToList();
                            list.Count.Should().Be(collection.Count);
                            foreach (var n in list)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToListOfT:
                        {
                            var list = collection.ToList<int>();
                            list.Count.Should().Be(collection.Count);
                            foreach (var n in list)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToHeap:
                        {
                            var heap = collection.ToHeap();
                            heap.Count.Should().Be(collection.Count);
                            foreach (var n in heap)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToHeapOfT:
                        {
                            var heap = collection.ToHeap<int>();
                            heap.Count.Should().Be(collection.Count);
                            foreach (var n in heap)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToMinHeap:
                        {
                            var minHeap = collection.ToMinHeap();
                            minHeap.Count.Should().Be(collection.Count);
                            foreach (var n in minHeap)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToMinHeapOfT:
                        {
                            var minHeap = collection.ToMinHeap<int>();
                            minHeap.Count.Should().Be(collection.Count);
                            foreach (var n in minHeap)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToQueue:
                        {
                            var queue = collection.ToQueue();
                            queue.Count.Should().Be(collection.Count);
                            foreach (var n in queue)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToQueueOfT:
                        {
                            var queue = collection.ToQueue<int>();
                            queue.Count.Should().Be(collection.Count);
                            foreach (var n in queue)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToStack:
                        {
                            var stack = collection.ToStack();
                            stack.Count.Should().Be(collection.Count);
                            foreach (var n in stack)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;
                        }
                    case IDsCollectionOperations.Type.ToStackOfT:
                        {
                            var stack = collection.ToStack<int>();
                            stack.Count.Should().Be(collection.Count);
                            foreach (var n in stack)
                            {
                                collection.Contains(n).Should().BeTrue();
                            }
                            break;

                        }
                }
            }        

            int RandomInput()
            {
                return random.Next(inputs.Length);
            }
        }
    }
}

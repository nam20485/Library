﻿using System.Collections;

using Library.DataStructures;

namespace Library.Tests
{
    public class IDsCollectionTests
    {
        [Theory]
        //[MemberData(nameof(Data))]
        //[ClassData(typeof(IntIDsCollectionTestData))]
        [ClassData(typeof(RandomIntIDsCollectionTestData))]
        public void TestIdsCollections(IDsCollection<int> collection, int[] inputs)
        {
            Console.WriteLine($"Original: {collection}");

            collection.Should().NotBeNull();
            collection.Should().BeEmpty();

            // set up collection 
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
        public void CantConstructWithNullCollection()
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
    }
}

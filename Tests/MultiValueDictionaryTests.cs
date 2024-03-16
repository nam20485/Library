using System.Runtime.CompilerServices;

using Library.DataStructures;

namespace Library.Tests
{
    public class MultiValueDictionaryTests
    {
        private static readonly Dictionary<string, System.Collections.Generic.List<string>> _animalsByKingdom =
            new()
            {
                ["bird"] = new() { "eagle", "hawk", "robin" },
                ["fish"] = new() { "bass", "cod", "trout" },
                ["mammal"] = new() { "bear", "cat", "dog" },
                ["reptile"] = new() { "alligator", "lizard", "snake" },
                ["amphibian"] = new() { "frog", "salamander", "toad" }
            };
        //new()
        //{
        //    ["bird"] = new() { "eagle", "hawk" },
        //    ["fish"] = new() { "bass", "cod" },
        //    ["mammal"] = new() { "bear", "cat" },
        //    ["reptile"] = new() { "alligator", "lizard" }
        //};

        [Fact]
        public void Test_ExceptWith()
        {
            // create two random KeyValuePairLists, R1 and R2
            // create two MVDs with R1 and R2, MVD1 and MVD2

            var kvp1 = KeyValuePairList<string, string>.CreateRandom(_animalsByKingdom, 10);
            var kvp2 = KeyValuePairList<string, string>.CreateRandom(_animalsByKingdom, 10);

            var hs1 = new System.Collections.Generic.HashSet<KeyValuePair<string, string>>(kvp1);
            var hs2 = new System.Collections.Generic.HashSet<KeyValuePair<string, string>>(kvp2);

            var mvd1 = new MultiValueDictionary<string, string>(kvp1);
            var mvd2 = new MultiValueDictionary<string, string>(kvp2);

            // perform set operation s, using R1 and R2
            // perform same set operation s, using MVD1 and MVD2

            // compare and determine if the result of s(R1, R2) is equiavalent to s(MVD1, MVD2).ToKVPList()            

            hs1.ExceptWith(hs2);
            mvd1.ExceptWith(mvd2);

            var mvd1sKvp = mvd1.Flatten();

            hs1.Should().BeEquivalentTo(mvd1sKvp);           
        }

        [Fact]
        public void Test_UnionWith()
        {
            // create two random KeyValuePairLists, R1 and R2
            // create two MVDs with R1 and R2, MVD1 and MVD2

            var kvp1 = KeyValuePairList<string, string>.CreateRandom(_animalsByKingdom, 10);
            var kvp2 = KeyValuePairList<string, string>.CreateRandom(_animalsByKingdom, 10);

            var hs1 = new System.Collections.Generic.HashSet<KeyValuePair<string, string>>(kvp1);
            var hs2 = new System.Collections.Generic.HashSet<KeyValuePair<string, string>>(kvp2);

            var mvd1 = new MultiValueDictionary<string, string>(kvp1);
            var mvd2 = new MultiValueDictionary<string, string>(kvp2);

            // perform set operation s, using R1 and R2
            // perform same set operation s, using MVD1 and MVD2

            // compare and determine if the result of s(R1, R2) is equiavalent to s(MVD1, MVD2).ToKVPList()            

            hs1.UnionWith(hs2);

            mvd1.UnionWith(mvd2);

            var mvd1sKvp = mvd1.Flatten();

            hs1.Should().BeEquivalentTo(mvd1sKvp);
        }

        [Fact]
        public void Test_IntersectWith()
        {
            // create two random KeyValuePairLists, R1 and R2
            // create two MVDs with R1 and R2, MVD1 and MVD2            

            var kvp1 = KeyValuePairList<string, string>.CreateRandom(_animalsByKingdom, 10);
            var kvp2 = KeyValuePairList<string, string>.CreateRandom(_animalsByKingdom, 10);

            var hs1 = new System.Collections.Generic.HashSet<KeyValuePair<string, string>>(kvp1);
            var hs2 = new System.Collections.Generic.HashSet<KeyValuePair<string, string>>(kvp2);

            var mvd1 = new MultiValueDictionary<string, string>(kvp1);
            var mvd2 = new MultiValueDictionary<string, string>(kvp2);

            // perform set operation s, using R1 and R2
            // perform same set operation s, using MVD1 and MVD2

            // compare and determine if the result of s(R1, R2) is equiavalent to s(MVD1, MVD2).ToKVPList()            

            hs1.IntersectWith(hs2);
            mvd1.IntersectWith(mvd2);

            var mvd1sKvp = mvd1.Flatten();

            hs1.Should().BeEquivalentTo(mvd1sKvp);
        }

        [Fact]
        public void Test_SymmetricExceptWith()
        {
            // create two random KeyValuePairLists, R1 and R2
            // create two MVDs with R1 and R2, MVD1 and MVD2            

            var kvp1 = KeyValuePairList<string, string>.CreateRandom(_animalsByKingdom, 10);
            var kvp2 = KeyValuePairList<string, string>.CreateRandom(_animalsByKingdom, 10);

            var hs1 = new System.Collections.Generic.HashSet<KeyValuePair<string, string>>(kvp1);
            var hs2 = new System.Collections.Generic.HashSet<KeyValuePair<string, string>>(kvp2);

            var mvd1 = new MultiValueDictionary<string, string>(kvp1);
            var mvd2 = new MultiValueDictionary<string, string>(kvp2);

            // perform set operation s, using R1 and R2
            // perform same set operation s, using MVD1 and MVD2

            // compare and determine if the result of s(R1, R2) is equiavalent to s(MVD1, MVD2).ToKVPList()            

            hs1.SymmetricExceptWith(hs2);            
            mvd1.SymmetricExceptWith(mvd2);

            var mvd1sKvp = mvd1.Flatten();

            hs1.Should().BeEquivalentTo(mvd1sKvp);
        }

        [Fact]
        public void Test_RandomIterations()
        {
            //var defaultOfIEnumerbleOfString = default(IEnumerable<string>);

            const int iterationCount = 100;
            for (int i = 0; i < iterationCount; i++)
            {
                Test_ExceptWith();
                Test_IntersectWith();
                Test_UnionWith();
                Test_SymmetricExceptWith();
            }
        }
    }
}

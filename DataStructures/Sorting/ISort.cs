using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures.Sorting
{
    public interface ISort<TInput>
    {
        TInput[] Sort(IEnumerable<TInput> inputs);
    }
}

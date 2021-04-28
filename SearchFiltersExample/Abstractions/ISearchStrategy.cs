using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFiltersExample
{
    public interface ISearchStrategy<T>
    {
        IReadOnlyCollection<T> Search(string term);
    }
}

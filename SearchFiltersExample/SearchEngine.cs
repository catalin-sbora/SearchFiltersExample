using SearchFiltersExample.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFiltersExample
{
    public class SearchEngine 
    {

        IDictionary<string, ISearchStrategy<Student>> searchStrategies = new Dictionary<string, ISearchStrategy<Student>>();

        public SearchEngine(ICollection<Student> students)
        {
           searchStrategies["name"] = new SearchStudentByName(students);
           searchStrategies["firstname"]  = new SearchStudentByFirstName(students);
        }

        public IReadOnlyCollection<Student> Search(SearchFilter filter)
        {
            if (searchStrategies.ContainsKey(filter.Name))
            {
                var strategy = searchStrategies[filter.Name];
                return strategy.Search(filter.Term);
            }
            else
            {
                return new List<Student>().AsReadOnly();
            }

        }
    }
}

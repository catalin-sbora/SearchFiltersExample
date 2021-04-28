using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFiltersExample.Filters
{
    public class SearchStudentByName : ISearchStrategy<Student>
    {
        private ICollection<Student> studentsList;
        public SearchStudentByName(ICollection<Student> students)
        {
            studentsList = students;
        }
        public IReadOnlyCollection<Student> Search(string term)
        {
            return studentsList.Where(student => student.LastName.Contains(term))
                                .ToList()
                                .AsReadOnly();
        }
    }
}

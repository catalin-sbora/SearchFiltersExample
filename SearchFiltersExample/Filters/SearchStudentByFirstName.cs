using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFiltersExample.Filters
{
    public class SearchStudentByFirstName: ISearchStrategy<Student>
    {
        private ICollection<Student> studentsList;
        public SearchStudentByFirstName(ICollection<Student> students)
        {
            studentsList = students;
        }
        public IReadOnlyCollection<Student> Search(string term)
        {
            return studentsList.Where(student => student.FirstName.Contains(term))
                                .ToList()
                                .AsReadOnly();
        }
    }
}

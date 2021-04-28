using SearchFiltersExample.Filters;
using System;
using System.Collections.Generic;

namespace SearchFiltersExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Search student");
            Console.Write("Enter search term: ");
            var searchTerm = Console.ReadLine();
            Console.Write("Search field: ");
            var searchField = Console.ReadLine();

            List<Student> students = new List<Student>{
                new Student{Id = 1, FirstName = "Stud1First", LastName = "Stud1Last"  },
                new Student{Id = 2, FirstName = "Stud2First", LastName = "Stud2Last"  },
                new Student{Id = 3, FirstName = "Stud3First", LastName = "Stud3Last"  },


            };

            SearchEngine engine = new SearchEngine(students);
            SearchFilter filter = new SearchFilter { Term = searchTerm, Name = searchField };
            ISearchStrategy<Student> nameStrategy = new SearchStudentByName(students);
            ISearchStrategy<Student> firstNameStrategy = new SearchStudentByFirstName(students);

            
            var results = engine.Search(filter);

            foreach (var stud in results)
            {
                Console.WriteLine($"{stud.Id}\t\t\t{stud.FirstName}\t\t\t{stud.LastName}");
            }
        }
    }
}

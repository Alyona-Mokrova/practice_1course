using System;
using System.Collections.Generic;
using System.Linq;

namespace task02
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public string Faculty { get; set; } = string.Empty;
        public List<int> Grades { get; set; } = new();
    }

    public class StudentService
    {
        private readonly List<Student> _students;
        public StudentService(List<Student> students) => _students = students;

        public IEnumerable<Student> GetStudentsByFaculty(string faculty)
            => _students.Where(Student => Student.Faculty == faculty);

        public IEnumerable<Student> GetStudentsWithMinAverageGrade(double minAverageGrade)
            => _students
                .Where(Student => Student.Grades != null)
                .Where(Student => Student.Grades.Average() >= minAverageGrade); 

        public IEnumerable<Student> GetStudentsOrderedByName()
            => _students
                .OrderBy(Student => Student.Name);

        public ILookup<string, Student> GroupStudentsByFaculty()
            => _students
                .ToLookup(Student => Student.Faculty);

        public string GetFacultyWithHighestAverageGrade()
            => _students
                .GroupBy(Student => Student.Faculty)
                .Select(group => new
                {
                    Faculty = group.Key,
                    AverageGrade = group.Where(Student => Student.Grades.Any()).SelectMany(Student => Student.Grades).DefaultIfEmpty(0).Average()
                })
                .OrderByDescending(f => f.AverageGrade)
                .Select(faculty => faculty.Faculty)
                .FirstOrDefault();
    }
}

namespace _04.AverageGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AverageGrades
    {
        static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int addStudents = 0; addStudents < studentsCount; addStudents++)
            {
                students.Add(new Student(Console.ReadLine().Split(' ')));
            }

            IOrderedEnumerable<Student> sortedStudents = students.OrderBy(x => x.Name).ThenByDescending(x => x.Grades.Average());

            foreach (Student student in sortedStudents)
            {
                double average = student.getAverageGrade();

                if (average >= 5.00)
                    Console.WriteLine($"{student.Name} -> {average.ToString("0.00")}");
            }
        }
    }
}

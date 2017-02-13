namespace _08.MentorGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MentorGroup
    {
        static void Main()
        {
            List<Student> group = new List<Student>();

            AddStudentAttendance(group);
            AddStudentComments(group);

            Print(group);
        }

        static void AddStudentAttendance(List<Student> Group)
        {
            for (int i = 0; ; i++)
            {
                string[] inPut = Console.ReadLine().Split(' ', ',');

                if (string.Join(" ", inPut) == "end of dates") break;
                if (!Group.Exists(x => x.Name == inPut[0]))
                    Group.Add(new Student(inPut[0]));

                for (int o = 1; o < inPut.Length; o++)
                {
                    Group.Find(x => x.Name == inPut[0]).AddAttendance(inPut[o]);
                }
            }
        }

        static void AddStudentComments(List<Student> Group)
        {
            for (int i = 0; ; i++)
            {
                string[] inPut = Console.ReadLine().Split('-');

                if (inPut[0] == "end of comments") break;

                if (Group.Exists(x => x.Name == inPut[0]))
                    Group.Find(x => x.Name == inPut[0]).AddComment(inPut[1]);
            }
        }

        static void Print(List<Student> Group)
        {
            foreach (Student student in Group.OrderBy(x => x.Name))
            {
                student.Attendance.Sort();
                Console.WriteLine(student.Name);
                Console.WriteLine("Comments:");
                foreach (string Comment in student.Comments)
                    Console.WriteLine($"- {Comment}");
                Console.WriteLine("Dates attended:");
                foreach (DateTime Date in student.Attendance)
                    Console.WriteLine($"-- {Date.ToString("dd/MM/yyyy")}");
            }
        }
    }
}

namespace _10.StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Town
    {
        public string Name;
        public int Seats;
        public List<Student> Students = new List<Student>();

        public IOrderedEnumerable<Student> SortedStudents()
        {
            return Students.OrderBy(x => x.RegistrationDate).ThenBy(x => x.Name).ThenBy(x => x.Mail);
        }

        public Town(List<string> inPut)
        {
            Name = inPut[0].Trim();

            Seats = int.Parse(inPut[1].Replace("seats", "").Trim());
        }

        public void AddStudent(List<string> inPut)
        {
            Students.Add(new Student(inPut));
        }

        public List<Student>[] StudyGroup()
        {
            int studyGroupsCount = (int)Math.Ceiling((double)Students.Count / Seats);

            List<Student>[] studyGroups = new List<Student>[studyGroupsCount];
            List<Student> sortedStudents = SortedStudents().ToList();

            int count = 0;
            int studyGroupIndex = 0;

            foreach (Student student in sortedStudents)
            {
                if (studyGroups[studyGroupIndex] == null)
                    studyGroups[studyGroupIndex] = new List<Student>();

                studyGroups[studyGroupIndex].Add(student);
                count++;

                if (count == Seats)
                {
                    studyGroupIndex++;
                    count = 0;
                }
            }

            return studyGroups;
        }
    }
}

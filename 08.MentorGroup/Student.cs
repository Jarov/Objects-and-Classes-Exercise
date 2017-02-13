namespace _08.MentorGroup
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    class Student
    {
        public string Name;
        public List<string> Comments = new List<string>();
        public List<DateTime> Attendance = new List<DateTime>();
        
        public Student(string name)
        {
            Name = name;
        }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }

        public void AddAttendance(string date)
        {
            DateTime Date = DateTime.ParseExact(date, "d/MM/yyyy", CultureInfo.InvariantCulture);
            Attendance.Add(Date);
        }
    }
}

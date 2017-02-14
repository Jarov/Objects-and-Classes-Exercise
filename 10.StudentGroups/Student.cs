namespace _10.StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    class Student
    {
        public string Name, Mail;
        public DateTime RegistrationDate;

        public Student(List<string> inPut)
        {
            Name = inPut[0].Trim();
            Mail = inPut[1].Trim();

            RegistrationDate = DateTime.ParseExact(inPut[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture);
        }
    }
}

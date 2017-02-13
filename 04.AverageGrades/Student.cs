namespace _04.AverageGrades
{
    using System.Collections.Generic;

    class Student
    {
        public string Name;
        public List<double> Grades = new List<double>();

        public Student(string[] inPut)
        {
            Name = inPut[0];

            for (int addGrades = 1; addGrades < inPut.Length; addGrades++)
                Grades.Add(double.Parse(inPut[addGrades]));
        }

        public double getAverageGrade()
        {
            double sum = 0;
            foreach (double grade in Grades)
                sum += grade;

            return sum / Grades.Count;
        }
    }
}

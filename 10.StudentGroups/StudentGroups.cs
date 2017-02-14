namespace _10.StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class StudentGroups
    {
        static void Main()
        {
            List<Town> cities = new List<Town>();

            ReadAndInsertEntry(cities);

            SortAndPrint(cities);
        }

        static void ReadAndInsertEntry(List<Town> Cities)
        {
            char[] SplitSeparators =
            {
                '=', '>', '|'
            };

            string currentTownName = "";

            for (int i = 0; ; i++)
            {
                string inPut = Console.ReadLine();

                if (inPut == "End") break;

                if (inPut.Contains("=>"))
                {
                    List<string> townInPut = inPut.Split(SplitSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (!Cities.Exists(x => x.Name == townInPut[0]))
                        Cities.Add(new Town(townInPut));

                    currentTownName = townInPut[0].Trim();
                }
                else
                {
                    List<string> studentInPut = inPut.Split(SplitSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();

                    Cities.Find(x => x.Name == currentTownName).AddStudent(studentInPut);
                }
            }
        }

        static void SortAndPrint(List<Town> cities)
        {
            StringBuilder outPut = new StringBuilder();

            var sortedCities = cities.OrderBy(x => x.Name).ThenBy(x => Convert.ToInt32(x.Students.Count / x.Seats) + 1);

            int TotalGroups = 0;

            bool DoAppendLine = true;

            foreach (Town city in sortedCities)
            {
                List<Student>[] currentTown = city.StudyGroup();

                foreach (List<Student> group in currentTown)
                {
                    outPut.Append($"{city.Name} => ");
                    bool WriteComma = true;

                    foreach (Student student in group)
                    {
                        outPut.Append($"{student.Mail}");

                        if (student == group.Last())
                            WriteComma = false;

                        if (WriteComma == true)
                            outPut.Append(", ");
                    }

                    outPut.AppendLine();

                    TotalGroups++;
                }
            }

            Console.WriteLine($"Created {TotalGroups} groups in {cities.Count} towns:");
            Console.WriteLine(outPut.ToString());
        }
    }
}

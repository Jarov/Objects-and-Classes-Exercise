namespace _09.TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TeamworkProjects
    {
        static void Main()
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>(teamsCount);
            AddTeam(teams, teamsCount);
            AssignMembers(teams);

            List<Team> disbandedTeams = new List<Team>();
            DisbandTeams(teams, disbandedTeams);

            SortAndPrint(teams, disbandedTeams);
        }

        static void AddTeam(List<Team> Teams,int TeamsCount)
        {
            for (int i = 0; i < TeamsCount; i++)
            {
                string[] inPut = Console.ReadLine().Split('-');

                if (Teams.Exists(x => x.Name == inPut[1]))
                    Console.WriteLine($"Team {inPut[1]} was already created!");
                else if (Teams.Exists(x => x.Creator == inPut[0]))
                    Console.WriteLine($"{inPut[0]} cannot create another team!");
                else
                {
                    Teams.Add(new Team(inPut));
                    Console.WriteLine($"Team {inPut[1]} has been created by {inPut[0]}!");
                }
            }
        }

        static void AssignMembers(List<Team> Teams)
        {
            for (int i = 0; ; i++)
            {
                string[] inPut = Console.ReadLine().Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                if (inPut[0] == "end of assignment") break;

                if (!Teams.Exists(x => x.Name == inPut[1]))
                    Console.WriteLine($"Team {inPut[1]} does not exist!");
                else if (Teams.Exists(x => x.Members.Contains(inPut[0])) || Teams.Exists(x => x.Creator == inPut[0]))
                    Console.WriteLine($"Member {inPut[0]} cannot join team {inPut[1]}!");
                else
                    Teams.Find(x => x.Name == inPut[1]).AddMember(inPut[0]);
            }
        }

        static void DisbandTeams(List<Team> Teams, List<Team> DisbandedTeams)
        {
            foreach (Team currentTeam in Teams)
            {
                if (currentTeam.Members.Count == 0)
                {
                    DisbandedTeams.Add(currentTeam);
                }
            }

            Teams.RemoveAll(x => x.Members.Count == 0);
        }

        static void SortAndPrint(List<Team> teams, List<Team> disbandedTeams)
        {
            var sortedTeams = teams.OrderBy(x => x.Name);

            foreach (Team currentTeam in sortedTeams)
            {
                currentTeam.Members.Sort();

                Console.WriteLine(currentTeam.Name);
                Console.WriteLine($"- {currentTeam.Creator}");

                foreach (string member in currentTeam.Members)
                    Console.WriteLine($"-- {member}");
            }

            Console.WriteLine("Teams to disband:");
            if (disbandedTeams.Count > 0)
            {
                var SortedDisbandedTeams = disbandedTeams.OrderBy(x => x.Name);
                
                foreach (Team currentTeam in SortedDisbandedTeams)
                {
                    Console.WriteLine(currentTeam.Name);
                }
            }
        }
    }
}

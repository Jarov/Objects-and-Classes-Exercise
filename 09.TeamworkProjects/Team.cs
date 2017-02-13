namespace _09.TeamworkProjects
{

    using System.Collections.Generic;

    class Team
    {
        public string Name;
        public string Creator;
        public List<string> Members = new List<string>();

        public Team(string[] inPut)
        {
            Name = inPut[1];
            Creator = inPut[0];
        }

        public void AddMember(string name)
        {
            if (!Members.Contains(name))
                Members.Add(name);
        }
    }
}

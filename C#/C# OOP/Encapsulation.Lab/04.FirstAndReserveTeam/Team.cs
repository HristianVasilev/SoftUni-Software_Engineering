using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        private const int boundaryAge = 40;

        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name => this.name;
        public IReadOnlyCollection<Person> FirstTeam => this.firstTeam;
        public IReadOnlyCollection<Person> ReserveTeam => this.reserveTeam;

        public void AddPlayer(Person person)
        {
            if (person.Age < boundaryAge)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }

    }
}

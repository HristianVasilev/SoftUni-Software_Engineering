using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        private List<Person> people;

        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People
        {
            get => this.people;
            set => this.people = value;
        }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = this.People.OrderByDescending(x => x.Age).FirstOrDefault();

            if (oldestPerson == null)
            {
                throw new ArgumentException("There is no person available!");
            }

            return oldestPerson;
        }
    }
}

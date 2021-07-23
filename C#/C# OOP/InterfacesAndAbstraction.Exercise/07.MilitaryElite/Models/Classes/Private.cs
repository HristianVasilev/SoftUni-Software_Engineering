using _07.MilitaryElite.Models.Interfaces;

namespace _07.MilitaryElite.Models.Classes
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public decimal Salary { get; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Salary:f2}";
        }

    }
}

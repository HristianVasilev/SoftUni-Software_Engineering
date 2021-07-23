using _07.MilitaryElite.Models.Enums;
using _07.MilitaryElite.Models.Interfaces;

namespace _07.MilitaryElite.Models.Classes
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public decimal Salary { get; }
        public Corps Corps { get; }

        public override string ToString()
        {
            return $"{base.ToString()}{System.Environment.NewLine}Corps: {Corps}";
        }

    }
}

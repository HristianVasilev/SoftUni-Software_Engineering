using _07.MilitaryElite.Models.Interfaces;

namespace _07.MilitaryElite.Models.Classes
{
    class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            return $"{base.ToString()}{System.Environment.NewLine}Code Number: {CodeNumber}";
        }
    }
}

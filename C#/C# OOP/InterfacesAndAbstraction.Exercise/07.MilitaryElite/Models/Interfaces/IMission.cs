using _07.MilitaryElite.Models.Enums;

namespace _07.MilitaryElite.Models.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; }
        public State State { get; }

        void CompleteMission();
    }
}

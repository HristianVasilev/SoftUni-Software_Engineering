namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const string racingBehavior = "aggressive";
        private const int drivingExperience = 10;
        private const int increasingDrivingExperiencePerRace = 5;

        public StreetRacer(string username, ICar car)
            : base(username, racingBehavior, drivingExperience, car) { }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += increasingDrivingExperiencePerRace;
        }
    }
}

namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using System;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable() || !racerTwo.IsAvailable())
            {
                string winnerUsername;
                string lostUsername;

                if (!racerOne.IsAvailable())
                {
                    winnerUsername = racerTwo.Username;
                    lostUsername = racerOne.Username;
                }
                else
                {
                    winnerUsername = racerOne.Username;
                    lostUsername = racerTwo.Username;
                }

                return String.Format(OutputMessages.OneRacerIsNotAvailable, winnerUsername, lostUsername);
            }

            racerOne.Race();
            racerTwo.Race();
            double racerOneChanceOfWinning = CalculateTheChanceOfWinning(racerOne);
            double racerTwoChanceOfWinning = CalculateTheChanceOfWinning(racerTwo);

            string winnerUserName;

            if (racerOneChanceOfWinning > racerTwoChanceOfWinning)
            {
                winnerUserName = racerOne.Username;
            }
            else
            {
                winnerUserName = racerTwo.Username;
            }

            return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winnerUserName);
        }

        private static double CalculateTheChanceOfWinning(IRacer racer)
        {
            double racerBehaviorMultiplier;

            if (racer.RacingBehavior == "strict")
            {
                racerBehaviorMultiplier = 1.2;
            }
            else if (racer.RacingBehavior == "aggressive")
            {
                racerBehaviorMultiplier = 1.1;
            }
            else
            {
                throw new InvalidOperationException();
            }

            return racer.Car.HorsePower * racer.DrivingExperience * racerBehaviorMultiplier;
        }
    }
}

namespace CarRacing.Core
{
    using CarRacing.Core.Contracts;
    using CarRacing.Models.Cars;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;

            switch (type)
            {
                case nameof(SuperCar):
                    car = new SuperCar(make, model, VIN, horsePower);
                    break;
                case nameof(TunedCar):
                    car = new TunedCar(make, model, VIN, horsePower);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            this.cars.Add(car);
            return String.Format(OutputMessages.SuccessfullyAddedCar, car.Make, car.Model, car.VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this.cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer;

            switch (type)
            {
                case nameof(ProfessionalRacer):
                    racer = new ProfessionalRacer(username, car);
                    break;
                case nameof(StreetRacer):
                    racer = new StreetRacer(username, car);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            this.racers.Add(racer);

            return String.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerOne == null || racerTwo == null)
            {
                string missedRacerUsername;

                if (racerOne == null)
                {
                    missedRacerUsername = racerOneUsername;
                }
                else
                {
                    missedRacerUsername = racerTwoUsername;
                }

                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, missedRacerUsername));
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IRacer racer in this.racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                sb.Append(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

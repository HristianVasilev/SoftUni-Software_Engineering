using System;

namespace _05.FootballTeamGenerator.Models
{
    class Player
    {
        private const byte bottomBoundary = 0;
        private const byte topBoundary = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;


        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }


        public string Name
        {
            get => name;
            set
            {
                if (value == string.Empty || value == null || value.Contains(' '))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public int Endurance
        {
            get { return endurance; }
            private set
            {
                ValidateInput(nameof(Endurance), value);
                endurance = value;
            }
        }

        public int Sprint
        {
            get { return sprint; }
            private set
            {
                ValidateInput(nameof(Sprint), value);
                sprint = value;
            }
        }

        public int Dribble
        {
            get { return dribble; }
            private set
            {
                ValidateInput(nameof(Dribble), value);
                dribble = value;
            }
        }

        public int Passing
        {
            get { return passing; }
            private set
            {
                ValidateInput(nameof(Passing), value);
                passing = value;
            }
        }

        public int Shooting
        {
            get { return shooting; }
            private set
            {
                ValidateInput(nameof(Shooting), value);
                shooting = value;
            }
        }

        public double SkillLevel => CalculateStats();



        private void ValidateInput(string statName, int value)
        {
            if (value < bottomBoundary || value > topBoundary)
            {
                throw new ArgumentException($"{statName} should be between {bottomBoundary} and {topBoundary}.");
            }
        }

        private double CalculateStats()
        {
            double sum = Endurance + Sprint + Dribble + Passing + Shooting;
            double average = sum / 5.00;

            return average;
        }
    }
}

﻿namespace Animals.Animals.Cats
{
    public class Tomcat : Cat
    {
        private const string gender = "Male";
        public Tomcat(string name, int age) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}

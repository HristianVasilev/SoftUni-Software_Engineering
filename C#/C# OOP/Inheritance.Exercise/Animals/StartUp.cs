using Animals.Animals;
using Animals.Animals.Cats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IList<Animal> animals = new List<Animal>();

            string animalType;
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] animalArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = animalArgs[0];
                int age = int.Parse(animalArgs[1]);
                string gender = animalArgs[2];

                Animal animal;

                try
                {
                    switch (animalType)
                    {
                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;
                        case "Cat":
                            animal = new Cat(name, age, gender);
                            break;
                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;
                        case "Kittens":
                            animal = new Kitten(name, age);
                            break;
                        case "Tomcat":
                            animal = new Tomcat(name, age);
                            break;

                        default:
                            throw new ArgumentException("Invalid input!");
                    }

                    animals.Add(animal);
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }

            }

            string result = GetResult(animals);
            Console.WriteLine(result);
        }

        private static string GetResult(IList<Animal> animals)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var animal in animals)
            {
                sb.AppendLine(animal.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

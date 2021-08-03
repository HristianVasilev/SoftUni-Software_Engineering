using _04.WildFarm.Models;
using _04.WildFarm.Models.Animals.Mammals.Felines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Animal animal = CreateAnimal(animalArgs);

                animals.Add(animal);

                string[] foodArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Food food = CreateFood(foodArgs);

                string askforFood = animal.AskForFood();
                Console.WriteLine(askforFood);

                try
                {
                    animal.Feed(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            string result = GetResult(animals);
            Console.WriteLine(result);
        }

        private static string GetResult(List<Animal> animals)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var animal in animals)
            {
                sb.AppendLine(animal.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private static Food CreateFood(string[] foodArgs)
        {
            string foodType = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            IEnumerable<Type> foodTypes = GetSubclasses<Food>();
            Type type = foodTypes.FirstOrDefault(t => t.Name == foodType);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid type!");
            }

            ParameterInfo[] parameterInfos = type.GetConstructors().FirstOrDefault().GetParameters();
            object[] arguments = GetArgumentsForConstructor(foodArgs.Skip(1).ToArray(), parameterInfos);

            ConstructorInfo constructorInfo = type.GetConstructors().First();
            Food food = (Food)constructorInfo.Invoke(arguments);
            return food;
        }

        private static Animal CreateAnimal(string[] animalArgs)
        {
            string typeName = animalArgs[0];

            IEnumerable<Type> animalTypes = GetSubclasses<Animal>();
            Type type = animalTypes.FirstOrDefault(t => t.Name == typeName);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid type!");
            }

            ParameterInfo[] parameterInfos = type.GetConstructors().FirstOrDefault().GetParameters();
            object[] arguments = GetArgumentsForConstructor(animalArgs.Skip(1).ToArray(), parameterInfos);

            ConstructorInfo constructorInfo = type.GetConstructors().First();
            Animal animal = (Animal)constructorInfo.Invoke(arguments);
            return animal;
        }

        private static object[] GetArgumentsForConstructor(string[] animalArgs, ParameterInfo[] parameterInfos)
        {
            object[] arguments = new object[parameterInfos.Length];

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                Type parameterType = parameterInfos[i].ParameterType;

                TypeConverter converter = TypeDescriptor.GetConverter(parameterType);
                var result = converter.ConvertFrom(animalArgs[i]);
                arguments[i] = result;
            }

            return arguments;
        }

        private static IEnumerable<Type> GetSubclasses<T>() where T : class
        {
            IEnumerable<Type> types = Assembly
                .GetAssembly(typeof(T))
                .GetTypes()
                .Where(c => c.IsClass && !c.IsAbstract && c.IsSubclassOf(typeof(T)));

            return types;
        }
    }
}

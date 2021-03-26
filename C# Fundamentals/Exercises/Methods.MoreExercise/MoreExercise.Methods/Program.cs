using System;

namespace MoreExercise.Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfInput = Console.ReadLine();
            string input = Console.ReadLine();
            DataTypes(typeOfInput, input);
        }
        static void DataTypes(string dataType, string data)
        {
            switch (dataType)
            {
                case "int":
                    Console.WriteLine(int.Parse(data) * 2);
                    break;
                case "real":
                    Console.WriteLine($"{(double.Parse(data)* 1.5):f2}");
                    break;
                case "string":
                    Console.WriteLine($"${data}$");
                    break;
                default:
                    Console.WriteLine("Invalid data type!");
                    break;
            }
        }
    }
}

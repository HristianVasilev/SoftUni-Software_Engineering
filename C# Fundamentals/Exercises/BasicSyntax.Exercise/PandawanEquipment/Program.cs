using System;

namespace PandawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            float amountOfMoney = float.Parse(Console.ReadLine());
            byte countOfStudents = byte.Parse(Console.ReadLine());
            float priceForSingleSabre = float.Parse(Console.ReadLine());
            float priceForSingleRobe = float.Parse(Console.ReadLine());
            float priceForSingleBelt = float.Parse(Console.ReadLine());

            float totalCost = (float)(priceForSingleSabre * Math.Ceiling((countOfStudents * 1.1))
                + priceForSingleRobe * (countOfStudents)
                + priceForSingleBelt * (countOfStudents - countOfStudents / 6));

            if (amountOfMoney >= totalCost)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalCost - amountOfMoney):F2}lv more.");
            }


        }
    }
}

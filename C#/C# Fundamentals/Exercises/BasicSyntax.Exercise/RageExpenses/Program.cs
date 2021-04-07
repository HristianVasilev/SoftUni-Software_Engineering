using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            float headsetPrice = float.Parse(Console.ReadLine());
            float mousePrice = float.Parse(Console.ReadLine());
            float keyboardPrice = float.Parse(Console.ReadLine());
            float displayPrice = float.Parse(Console.ReadLine());

            byte trashKeyboard = 0;
            float expences = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                bool trashHeadset = false;
                bool trashMouse = false;

                if (i % 2 == 0)
                {
                    trashHeadset = true;
                    expences += headsetPrice;
                }

                if (i % 3 == 0)
                {
                    trashMouse = true;
                    expences += mousePrice;
                }

                if (trashHeadset && trashMouse)
                {
                    trashKeyboard++;
                    expences += keyboardPrice;
                }

                if (trashKeyboard == 2)
                {
                    expences += displayPrice;
                    trashKeyboard = 0;
                }
            }

            Console.WriteLine($"Rage expenses: {expences:F2} lv.");
        }
    }
}

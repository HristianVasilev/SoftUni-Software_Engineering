using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsetTrash = 0;
            int mouseTrash = 0;
            int keyboardTrash = 0;
            int displayTrash = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                bool secondTrashOfKeyboard = false;
                if (i % 2 == 0)
                {
                    headsetTrash++;
                }
                if (i % 3 == 0)
                {
                    mouseTrash++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardTrash++;
                    if (keyboardTrash % 2 == 0)
                    {
                        secondTrashOfKeyboard = true;
                    }
                }
                if (keyboardTrash % 2 == 0 && keyboardTrash != 0 && secondTrashOfKeyboard == true)
                {
                    displayTrash++;
                }
            }
            double expenses = headsetPrice * headsetTrash + mousePrice * mouseTrash + keyboardPrice * keyboardTrash + displayPrice * displayTrash;
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}

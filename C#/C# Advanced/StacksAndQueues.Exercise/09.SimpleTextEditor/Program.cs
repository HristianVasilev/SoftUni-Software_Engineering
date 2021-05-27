using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            Stack<string> textStory = new Stack<string>();
            string text = string.Empty;

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int command = int.Parse(tokens[0]);

                switch (command)
                {
                    case 1:
                        //Appends someString to the end of the text
                        string someString = tokens[1];
                        Append(someString, ref text, ref textStory);
                        break;
                    case 2:
                        //Erases the last count elements from the text
                        int count = int.Parse(tokens[1]);
                        Erase(count, ref text, ref textStory);
                        break;
                    case 3:
                        //Returns the element at position index from the text
                        int index = int.Parse(tokens[1]);
                        char stringAtIndex = IndexOf(index, ref text);
                        output.AppendLine(stringAtIndex.ToString());
                        break;
                    case 4:
                        //Undoes the last not undone command of type 1/2 and returns the text to the state before that operation
                        Undoe(ref text, ref textStory);
                        break;
                }
            }

            Console.WriteLine(output.ToString());
        }

        private static void Undoe(ref string text, ref Stack<string> textStory)
        {
            text = textStory.Pop();
        }

        private static char IndexOf(int index, ref string text)
        {
            return text[index - 1];
        }

        private static void Erase(int count, ref string text, ref Stack<string> textStory)
        {
            UpdateStory(ref text, ref textStory);

            text = text.Remove(text.Length - count, count);
        }

        private static void Append(string someString, ref string text, ref Stack<string> textStory)
        {
            UpdateStory(ref text, ref textStory);
            text += someString;
        }

        private static void UpdateStory(ref string currentText, ref Stack<string> textStory)
        {
            textStory.Push(currentText);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        private static List<string> lessons;

        static void Main(string[] args)
        {
            lessons = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] commandArgs = command.Split(':', StringSplitOptions.RemoveEmptyEntries);

                string lessonTitle = commandArgs[1];

                switch (commandArgs[0])
                {
                    case "Add":
                        Add(lessonTitle);

                        break;
                    case "Insert":
                        int index = int.Parse(commandArgs[2]);
                        Insert(lessonTitle, index);

                        break;
                    case "Remove":
                        Remove(lessonTitle);

                        break;
                    case "Swap":
                        string lessonTitle2 = commandArgs[2];
                        Swap(lessonTitle, lessonTitle2);

                        break;
                    case "Exercise":
                        Exercise(lessonTitle);

                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            PrintOutput();
        }

        private static void PrintOutput()
        {
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }

        private static void Exercise(string lessonTitle)
        {
            if (!LessonExists(lessonTitle))
            {
                lessons.Add(lessonTitle);
                lessons.Add($"{lessonTitle}-Exercise");
                return;
            }

            if (!LessonExists($"{lessonTitle}-Exercise"))
            {
                int indexOfLesson = lessons.IndexOf(lessonTitle);
                lessons.Insert(indexOfLesson + 1, $"{lessonTitle}-Exercise");
            }
        }

        private static void Swap(string lessonTitle, string lessonTitle2)
        {
            if (!LessonExists(lessonTitle) || !LessonExists(lessonTitle2))
            {
                return;
            }

            int indexOfLessonOne = lessons.IndexOf(lessonTitle);
            int indexOfLessonTwo = lessons.IndexOf(lessonTitle2);

            lessons[indexOfLessonOne] = lessonTitle2;
            lessons[indexOfLessonTwo] = lessonTitle;

            if (LessonExists($"{lessonTitle}-Exercise") && LessonExists($"{lessonTitle2}-Exercise"))
            {
                lessons[indexOfLessonOne + 1] = $"{lessonTitle2}-Exercise";
                lessons[indexOfLessonTwo + 1] = $"{lessonTitle}-Exercise";
                return;
            }

            if (LessonExists($"{lessonTitle}-Exercise"))
            {
                lessons.Remove($"{lessonTitle}-Exercise");
                lessons.Insert(indexOfLessonTwo + 1, $"{lessonTitle}-Exercise");
            }

            if (LessonExists($"{lessonTitle2}-Exercise"))
            {
                lessons.Remove($"{lessonTitle2}-Exercise");
                lessons.Insert(indexOfLessonOne + 1, $"{lessonTitle2}-Exercise");
            }
        }

        private static void Remove(string lessonTitle)
        {
            if (!LessonExists(lessonTitle))
            {
                return;
            }

            lessons.Remove(lessonTitle);

            if (LessonExists($"{lessonTitle}-Exercise"))
            {
                lessons.Remove($"{lessonTitle}-Exercise");
            }
        }

        private static void Insert(string lessonTitle, int index)
        {
            if (LessonExists(lessonTitle))
            {
                return;
            }

            lessons.Insert(index, lessonTitle);
        }

        private static void Add(string lessonTitle)
        {
            if (LessonExists(lessonTitle))
            {
                return;
            }

            lessons.Add(lessonTitle);
        }

        private static bool LessonExists(string lessonTitle)
        {
            return lessons.Contains(lessonTitle);
        }
    }
}

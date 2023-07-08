using System;

namespace TextEngine
{
    public static class Functions
    {
        private static Dictionary<string, int> variables = new Dictionary<string, int>();

        public static void TypeWriter(string content)
        {
            foreach (char c in content)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        public static void Dialog(string content)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            TypeWriter(content);
            Console.ResetColor();
        }

        public static void WriteText(string content, TextType type)
        {
            ConsoleColor foregroundColor;
            ConsoleColor backgroundColor = ConsoleColor.Black;

            switch (type)
            {
                case TextType.Title:
                    foregroundColor = ConsoleColor.Cyan;
                    break;
                case TextType.Narrative:
                    foregroundColor = ConsoleColor.Gray;
                    break;
                case TextType.Option:
                    foregroundColor = ConsoleColor.Blue;
                    break;
                default:
                    foregroundColor = ConsoleColor.Gray;
                    break;
            }

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(content);

            Console.ResetColor();
        }

        public static string ReadText(string prompt, TextType type = TextType.Option)
        {
            WriteText(prompt, type);
            return Console.ReadLine();
        }

        public static string Action(string action)
        {
            return Consequence(action);
        }

        public static string Consequence(string action)
        {
            return $"You chose the action '{action}', but nothing happened.";
        }

    }
}

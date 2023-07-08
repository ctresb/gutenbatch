using System;
using TextEngine;

namespace TextEngine
{
    class Engine
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("▒█▀▀█ ▒█░▒█ ▀▀█▀▀ ▒█▀▀▀ ▒█▄░▒█ ▒█▀▀█ ░█▀▀█ ▀▀█▀▀ ▒█▀▀█ ▒█░▒█");
                Console.WriteLine("▒█░▄▄ ▒█░▒█ ░▒█░░ ▒█▀▀▀ ▒█▒█▒█ ▒█▀▀▄ ▒█▄▄█ ░▒█░░ ▒█░░░ ▒█▀▀█");
                Console.WriteLine("▒█▄▄█ ░▀▄▄▀ ░▒█░░ ▒█▄▄▄ ▒█░░▀█ ▒█▄▄█ ▒█░▒█ ░▒█░░ ▒█▄▄█ ▒█░▒█");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nChoose an option:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Load story");
                Console.WriteLine("2. Create story");
                Console.WriteLine("3. Edit story");
                Console.ResetColor();
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        string storyFilename = Functions.ReadText("Please enter the story file name:", TextType.Option);
                        StoryLoader.LoadStory(storyFilename);
                        break;
                    case "2":
                        string storyTitle = Functions.ReadText("Please enter a name for the new story:", TextType.Option);
                        Gutenberg.NewFile(storyTitle);
                        break;
                    case "3":
                        string storyTitleToEdit = Functions.ReadText("Please enter the name of the story you want to edit:", TextType.Option);
                        Gutenberg.EditFile(storyTitleToEdit);
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}

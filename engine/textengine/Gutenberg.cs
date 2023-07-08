using System;
using System.IO;
using System.Collections.Generic;

namespace TextEngine
{
    public static class Gutenberg
    {
        private static List<string> tempStory = new List<string>();

        public static void NewFile(string title)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "stories", $"{title}.story");

            if (File.Exists(path))
            {
                Functions.Dialog($"A story called {title} already exists. Please choose another name.");
            }
            else
            {
                using (FileStream fs = File.Create(path))
                {
                    //Create empty file
                }
                Functions.Dialog($"Story '{title}' created successfully!");
                EditFile(title);
            }
        }

        public static void EditFile(string title)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "stories", $"{title}.story");

            if (!File.Exists(path))
            {
                Functions.Dialog($"Could not find the story {title}. Please check the name and try again.");
            }
            else
            {
                string line = "";
                string input = "";

                do
                {
                    Console.Clear();
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Add title");
                    Console.WriteLine("2. Add dialogue");
                    Console.WriteLine("3. Add text");
                    Console.WriteLine("4. Add input");
                    Console.WriteLine("5. View story");
                    Console.WriteLine("6. Save and exit");

                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            line = Functions.ReadText("Enter the title:", TextType.Title);
                            tempStory.Add($"{{TEXT(Title)[{line}]}}");
                            break;
                        case "2":
                            line = Functions.ReadText("Enter the dialogue:", TextType.Dialog);
                            tempStory.Add($"{{TEXT(Dialog)[{line}]}}");
                            break;
                        case "3":
                            line = Functions.ReadText("Enter the text:", TextType.Narrative);
                            tempStory.Add($"{{TEXT(Narrative)[{line}]}}");
                            break;
                        case "4":
                            line = Functions.ReadText("Enter the input:", TextType.Option);
                            input = Functions.ReadText("Enter the input description:", TextType.Option);
                            tempStory.Add($"{{INPUT({line})[{input}]}}");
                            break;
                        case "5":
                            foreach (string str in tempStory)
                            {
                                Console.WriteLine(str);
                            }
                            Console.ReadLine();
                            break;
                        case "6":
                            string confirmation = Functions.ReadText("Are you sure you want to save and exit? (Y/N)", TextType.Option);

                            if (confirmation.ToLower() == "Y")
                            {
                                using (StreamWriter sw = new StreamWriter(path))
                                {
                                    foreach (string str in tempStory)
                                    {
                                        sw.WriteLine(str);
                                    }
                                }
                                Functions.Dialog($"Story '{title}' saved successfully!");
                                return;
                            }
                            break;
                        default:
                            Functions.Dialog("Invalid option.");
                            break;
                    }
                } while (true);
            }
        }
    }
}
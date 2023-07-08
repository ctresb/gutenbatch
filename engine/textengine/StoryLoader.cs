using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TextEngine
{
    public static class StoryLoader
    {
        public static void LoadStory(string filename)
        {
            if (!filename.EndsWith(".story"))
            {
                filename += ".story";
            }

            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "stories", filename);

            if (!File.Exists(fullPath))
            {
                Functions.Dialog("Story not found. Please make sure your .story file is in the 'stories' folder");
                return;
            }

            var lines = File.ReadAllLines(fullPath);
            var variables = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                if (line.StartsWith("{INPUT"))
                {
                    var match = Regex.Match(line, @"{INPUT\((\w+)\)\[(.+)\]}");
                    if (match.Success)
                    {
                        var varName = match.Groups[1].Value;
                        var prompt = match.Groups[2].Value;
                        var response = Functions.ReadText(prompt, TextType.Option);
                        variables[varName] = response;
                    }
                }
                else if (line.StartsWith("{TEXT"))
                {
                    var match = Regex.Match(line, @"{TEXT\((\w+)\)\[(.+)\]}");
                    if (match.Success)
                    {
                        var textType = match.Groups[1].Value;
                        var content = match.Groups[2].Value;

                        foreach (var variable in variables)
                        {
                            content = content.Replace("{" + variable.Key + "}", variable.Value);
                        }

                        if (textType.Equals("Dialog", StringComparison.InvariantCultureIgnoreCase))
                        {
                            Functions.Dialog(content);
                        }
                        else if (Enum.TryParse(textType, true, out TextType type))
                        {
                            Functions.WriteText(content, type);
                        }
                    }
                }
            }
        }
    }
}

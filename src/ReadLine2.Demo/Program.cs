using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ReadLine2 Library Demo");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            string[] history = new string[] { "ls -a", "dotnet run", "git init" };
            ReadLine2.AddHistory(history);

            ReadLine2.AutoCompletionHandler = new AutoCompletionHandler();

            string input = ReadLine2.Read("(prompt)> ");
            Console.WriteLine(input);

            input = ReadLine2.ReadPassword("Enter Password> ");
            Console.WriteLine(input);
        }
    }

    class AutoCompletionHandler : IAutoCompleteHandler
    {
        public char[] Separators { get; set; } = new char[] { ' ', '.', '/', '\\', ':' };
        public string[] GetSuggestions(string text, int index)
        {
            if (text.StartsWith("git "))
                return new string[] { "init", "clone", "pull", "push" };
            else
                return null;
        }
    }
}

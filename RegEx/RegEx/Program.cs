using System.Text.RegularExpressions;

namespace RegEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teeme regular expresion harjutuse");

            string word = "#CD5C5Cy";
            Console.WriteLine("Hex code: " + word);
            Console.WriteLine("kas on regex: " + Regextest(word));
        }
        public static bool Regextest(string word)
        {
            //regular expression kontrollib kas sisestatav string vastab nõuetele
            return Regex.IsMatch(word, @"[#][0-9A-Fa-f]{6}\b");
        }
    }
}

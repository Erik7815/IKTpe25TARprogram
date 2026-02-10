using System.Threading.Channels;

namespace Enum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enum");
            Console.WriteLine(Weekdays.Friday);
            int day = (int)DayOfWeek.Friday;
            Console.WriteLine(day);
            Console.WriteLine("------------------------");

            Console.WriteLine(colors.White);
            
        }
        enum Weekdays
        {
            Monday, 
            Tuesday, 
            Wednesday, 
            Thursday, 
            Friday, 
            Saturday, 
            Sunday
        }
        enum colors
        {
            Red = 3,
            Green = 10,
            Blue = 13,
            Yellow = 5,
            Black = 1,
            White = 8,

        }
    }
}
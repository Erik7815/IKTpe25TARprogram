namespace MinMaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List numbrites");

            int[] numbers = new int [10] { 2, 12, 15, 11, 6, 9, 41, 47, 5, 67 };

            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Sorteerib numbrid alates väiksemast suuremani");

            Array.Sort(numbers);
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("");

            //sorteerib numbrid alates suuremast väiksemani
            Array.Reverse(numbers);
            foreach (int j in numbers)
            {
                Console.WriteLine(j);
                
            }
        }
    }
}

namespace SortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Sortedlist();
                    break;
                    case 2:
                    Tuple();
                        break;
                    default:
                    break;
            }
            
        }
        static void Sortedlist()
        {
            SortedList<int, string> sort = new SortedList<int, string>();
            sort.Add(1, "üks");
            sort.Add(2, "kaks");
            foreach (var item in sort)
            {
                Console.WriteLine(item.Value + item.Key);
            }
        }
        static void Tuple()
        {
            var tupl = (32 , "hello");
            Console.WriteLine(tupl.Item1  + tupl.Item2);
        }
    }
}

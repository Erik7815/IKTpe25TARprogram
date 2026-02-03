namespace Dictionar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("dictionary ja foreach!");

            // var on muutuja 
            int nr = 1;
            var domains = new Dictionary<string, string>()
            {
                {"fi", "Finland" },
                {"se", "Sweden" },
                {"de", "Germany" },
                {"fr", "France" },
                {"es", "Spain" }
            };
            //kasutate foreach-i ja juurde tuleb lisada kolmas rida
            foreach (var domain in domains)
            {
                Console.WriteLine($"{domain.Key} - {domain.Value} - {nr}");
                nr++;
            }
        }
    }
}

using System.Runtime.InteropServices;

namespace ListLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List and LINQ");

            //teeme "andmebaasi"
            //selleks on vaja luua class nimega person
            //mis on muutuja all nimega person
            IList<Person> person = new List<Person>()
            {
               new Person() {Id = 1, Name = "Juku", Age = 10},
               new Person() {Id = 2, Name = "Juhan", Age = 11},
               new Person() {Id = 3, Name = "Maali", Age = 9},
               new Person() {Id = 4, Name = "Aksel", Age = 10},
            };
            //nüüd kasutame person muutujat uuue muutuja all
            //millle nimeks on persons
            var persons = from p in person
                          select new
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Age = p.Age
                          };
            //kasutame muutujat persons, et näidata konsoolis tulemust
            foreach (var item in persons)
            {
                Console.WriteLine("id on " + item.Id + " ja nimi on " + item.Name);
            }
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("kasutame LINNQ selecti ehk teine variant");
            //siin koondame kogu info result muutuja sisse
            var result = person
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age
                });
            //kasutame result muutujat ja teeme ta lahti rea kaupa
            //läbi muutuja item
            foreach (var item in result)
            {
                Console.WriteLine("id on " + item.Id + " ja nimi on " + item.Name);
            }
        }
    }
}

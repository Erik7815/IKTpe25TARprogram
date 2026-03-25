namespace Inheritance2
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Inheritance 2");

            //kui siin on Water class, siis kuvatakse seal olevat DoSomething meetodi sisu
            //kui panna Water = new River(); siis kuvatakse River classis olevat DOSomething
            //meetodi sisu
            Water water = new Water();

            Water water2 = new Lake();
            water2.Flow = true;
            water2.Length = "123";

            Water water3 = new Lake();
            water3.Length = "987";
            water3.Flow = false;

            //kutsume soovitud meetodi esile.
            water.dosomething();
            water2.dosomething();
            water3.dosomething();
        }

    }
}

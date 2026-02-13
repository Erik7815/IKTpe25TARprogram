namespace StructProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Struct");
            Coordinate point = new Coordinate(5, 6);
            Console.WriteLine(point.X);
            Console.WriteLine(point.Y);
            Console.WriteLine("-----------------");

            IntAndstring intandstring = new IntAndstring();
            Console.WriteLine(intandstring.Age);
            Console.WriteLine(intandstring.Name);

            InsertedIntAndString inserted = new InsertedIntAndString("tallinn", 3000);
            Console.WriteLine(inserted.City);
            Console.WriteLine(inserted.PostalCode);
        }
    }
    //mis on struct
    //see on väärtustüüp (value type), mis sarnaneb klassile
    struct Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
        {
            x = 6;
            y = 9;

            X = x;
            Y = y;
        }
    }
    //tha struct nimga IntAndstring
    //string city ja int postalcode
    //kutsuda see struct mainis välja
    //structi sees tuleb sellele anda juba väärtus
    struct IntAndstring
    {
        public string Name;
        public int Age;

        public IntAndstring(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    struct InsertedIntAndString
    {
        public string City;
        public int PostalCode;

        public InsertedIntAndString(string city, int postalCode)
        {
            City = city;
            PostalCode = postalCode;

            
        }
    }
}

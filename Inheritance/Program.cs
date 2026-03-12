using System.Reflection.Metadata.Ecma335;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert to first  number ");
            Console.WriteLine("First number: ");
            int firsttnr = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Secondnumber: ");
            int secondnr = Convert.ToInt32(Console.ReadLine());

            Rectangle rectangle = new Rectangle();
            rectangle.SetWidth(firsttnr);
            rectangle.SetHeight(secondnr);
            Console.WriteLine("Total area: {0}", rectangle.getarea());
        }
    }
    class shape
    {
        public void SetWidth(int w)
        {
            width = w;
        }
        public void SetHeight(int h)
        {
            height = h;
        }
        protected int width;
        protected int height;
    }
    //koolon tähendab pärimist 
    //läbi pärimise saame kasutda muutujaid width ja length

    class Rectangle : shape
    {
        public int getarea()
        {
            //return tagastab info selles meetodis toimunud loogika kohta
            return (width * height);
        }
    }
}

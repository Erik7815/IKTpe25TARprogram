namespace InheritanceVIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Masina number");
            int vincode = Convert.ToInt32(Console.ReadLine());
            Machine machine = new Machine();
            machine.Vinkood(vincode);
            Console.WriteLine("VIN kood: " + machine.Vinkood);
        }
    }
    class Machine : Cars
    {
        public int masinanumber()
        {
            return vin;
        }
    }
    class Cars
    {
       public void Vinkood(int vincode)
        {
            vin = vincode;
        }
            
        protected int vin;
    }
    
}

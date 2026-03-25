namespace Inheritance2
{
     class Water
    {
        public bool Flow;
        public string Length;
        //siin on dosomething method mida viidatatkse River classi all.
        //see võib olla virtual ja ei pea override kuna teda kirjutatakse üle 
        public virtual void dosomething()
        {
            Console.WriteLine("do something method");

        }
    }
    //internal class WaterProp
    //{
    //    public bool Flow;
    //    public string Length;
    //}
}

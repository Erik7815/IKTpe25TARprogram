

namespace Inheritance2
{
    internal class Lake : Water
    {
        public override void DoSomething()
        {
            //Water classis on olemas muutujad Flow ja length ja sellepärast ei pea neid siin uuesti defineerima
            Console.WriteLine("This is the river method and " + Flow + " is and " + Length + "is in meters");
        }
    }
}

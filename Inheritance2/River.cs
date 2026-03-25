namespace Inheritance2
{
    //river antud juhul alamklass ja viitab Waterile e peamisele classile
     class River : Water
    {
        //kui kirjutan override, siis kirjutab water meetodis oleva DoSomething meetodi üle
        //kui panen siia public virtual void, siis ei kirjuat Water meetodi Dosomething-t üle
        public override void DoSomething() 
        {
            //Water classis on olemas muutujad Flow ja length ja sellepärast ei pea neid siin uuesti defineerima
            Console.WriteLine("This is the river method and " + Flow + " is and " + Length + "is in meters");
        }
    }
}

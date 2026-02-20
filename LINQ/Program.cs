namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //tuleb teha class nimega peoplelist 
            //seal on 6 rida andmeid 
            //kindlasti peab olema kaks mari nimega isikut aga erinevate vanustega

            Console.WriteLine("tee valik numbriga");
            Console.WriteLine("1. ThenbyLinq");
            Console.WriteLine("2. THenByDescending");
            Console.WriteLine("3. SelectLINQ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ThenbyLinq();
                    break;

                    case 2:
                        THenByDescending();
                    break;

                    case 3:
                        SelectLINQ();
                    break;

                    default:
                    Console.WriteLine("Vale valik");
                    break;
            }
        }
        public static void ThenbyLinq()
        {
            //theby sorteerib numbrilises järjestuses
            var ThenbyResult = People.peoples
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Age);
            Console.WriteLine("Thenby järgi sorteerimine");
            foreach (var people in ThenbyResult)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
            
        }
        public static void THenByDescending()
        {
            var ThenbyResult = People.peoples
                .OrderByDescending(x => x.Name)
                .ThenByDescending(x => x.Age);
            foreach (var people in ThenbyResult)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }
        public static void SelectLINQ()
        {
            //select lihtasalt tagastab andmed nii nagu need on andmebaasis
            //sama hea mis SQL select
            var ThenbyResult = People.peoples
                .Select(x => new 
                { Name = x.Name,
                    Age = x.Age });
            foreach (var people in ThenbyResult)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }
    }
}

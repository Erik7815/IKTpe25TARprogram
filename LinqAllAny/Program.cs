namespace LinqAllAny
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! LINQ");
            Console.WriteLine("1. All");
            Console.WriteLine("2. Any");
            Console.WriteLine("3. Join");

            int choice = int.Parse(Console.ReadLine());
            switch  (choice)
            {
                case 1:
                    ALLLINQ();
                    break;
                    case 2:
                        AnyLINQ();
                    break;
                    case 3:
                        JoinLINQ();
                    break;

                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }
        public static void ALLLINQ()
        {
            //Kasutate ALL
            //kontrollite kas on vanemaid kui 12 ja nooremaid kui 20
            var ages = StudentData.students.All(x => x.Age > 12 && x.Age < 20);
            Console.WriteLine("Kas inimesed on õige vanusega? " + ages);
        }
        //teeme uue meetodi nimega AnyLINQ
        //kasutada any-t 
        //vastus on true
        public static void AnyLINQ()
        {
            var result = StudentData.students.Any(x => x.Age > 12 && x.Age < 20);
            Console.WriteLine(result);
        }
        //teha meetod nimega JoinLINQ
        //kasutada join-i
        public static void JoinLINQ()
        {
            var result = StudentData.students.Join
                (
                StandartData.standarts,
                students => students.StandartID,
                standartID => standartID.StandartID,
                (students, standartId) => new
                {
                    name = students.Name,
                    standartId = standartId.StandartID
                }
                );

            foreach (var item in result)
            {
                Console.WriteLine(item.name, item.standartId);
            }
        }
    }
}

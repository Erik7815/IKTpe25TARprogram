using System;
using System.Net.Http.Headers;
using Microsoft.Win32.SafeHandles;

namespace LINQTakeSkip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kutsume esile LINQ meetodid");
            Console.WriteLine("1. skip");
            Console.WriteLine("2. skipWhile");
            Console.WriteLine("3. takeWhile");
            Console.WriteLine("4. FirstOrDefault");
            Console.WriteLine("5. AverageLINQ");
            Console.WriteLine("6. CountLINQ");
            Console.WriteLine("7. SUM");
            Console.WriteLine("8. Max");
            //siin kasuta swwichi ja peab saama skip meetodit esile kutsuda
            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    skip();
                    break;

                    case "2":
                        whileskip();
                    break;

                    case "3":
                    whiletake();
                    break;

                    case "4":
                        firstOrDefault();
                    break;

                    case "5":
                        averagelinq();
                    break;

                    case "6":
                        countLINQ();
                    break;

                case "7":
                    suml();
                    break;

                case "8":
                    max();
                    break;

                    case "9":
                    minlinq();
                    break;


                    default:
                    break;
            }
        }

        public static void skip()
        {
            Console.WriteLine("------------Skip----------------");
            //kasuta skip ja jäta kolm tükki vahele
            var skip = PeopleList.peoples.Skip(3);
            foreach (var people in skip)
            {
                Console.WriteLine(people.Name);
            }
        }
        //teete uue meetodi aga kasutate skipwhile ja vanemad kui 18  peab olema tingimus
        public static void whileskip()
        {
            Console.WriteLine("------------SkipWhile----------------");
            //mis tähendab => . See tähendab lambda märji ja selle 
            //abil saab kasutada pikema classi ni,etuse asemel lühendit
            //koos sees oleva muutujaga, mis antud juhul on X.
            var skipwhile = PeopleList.peoples.SkipWhile(x => x.Age > 18);
            foreach (var item in skipwhile)
            {
                Console.WriteLine($"{item.Id} " + $"{item.Name} " + item.Age);
            }
            //Skipwhile jätab loendis nii kaua vahele ridu kuni vastab tingimusele
            //e antud juhul jätab read vahele kuuni leiab 18 a isiku ja peale seda 
            //hakkab infot jälle kuvama olenemata vanuse tingmiusest
        }
        //kasutada Takewhile ja kutsuda see esile switchis 
        public static void whiletake()
        {
            Console.WriteLine("------------TakeWhile----------------");
            var skipwhile = PeopleList.peoples.TakeWhile(x => x.Age > 18);
            foreach (var item in skipwhile)
            {
                Console.WriteLine($"{item.Id} " + $"{item.Name} " + item.Age);
            }
            //takewhile näitab isikuid kuni vastab tingimusele 
            //e antud juhul näitab andmeid kuni leiab 18 a isisku ja 
            //peale seda hakkab enam ei näitab andmeids
        }
        public static void firstOrDefault()
        {
            //kuvab esimese elemendi, mis järjestab tingimusele
            Console.WriteLine("------------SkipWhile----------------");
            var first = PeopleList.peoples.FirstOrDefault(person => person.Name.Length > 5).Name;
            Console.WriteLine("The first long name is '{0}'." + first);
        }
        //kasutame average LINQ
        public static void averagelinq()
        {
            Console.WriteLine("-------------AverageLINQ-------------");
            var avarage = PeopleList.peoples.Average(person => person.Age);
            Console.WriteLine(avarage);
        }
        public static void countLINQ()
        {
            var totalpersons = PeopleList.peoples.Count();
            Console.WriteLine("Inimesi on kokku: " + totalpersons);
            Console.WriteLine("----------------------------------");
            var adultprson = PeopleList.peoples.Count(x => x.Age >= 18);
        }
        public static void suml()
        {
            var persons = PeopleList.peoples.Sum(x => x.Age);
            Console.WriteLine("Täisealiste isikute koondarv" + persons);
            Console.WriteLine("----------------------------------");
            var sumAdults = 0;
            var numAdults = PeopleList.peoples.Sum(x =>
            {
                if (x.Age > 18)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });
            Console.WriteLine("Täisisikute koondarv " + numAdults);

        }
        public static void max()
        {
            var mxa = PeopleList.peoples.Max(person => person.Age);
            Console.WriteLine("Kõige vanem isik on " + mxa);
        }
        public static void minlinq()
        {
            var mxa = PeopleList.peoples.Min(person => person.Age);
            Console.WriteLine("Kõige noorem isik on " + mxa);
        }
    }
}
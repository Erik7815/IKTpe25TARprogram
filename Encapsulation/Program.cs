using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Encapsulation.Service;

namespace Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Encapsulation e kaspledamine");

            //ligipääs classile Student ei ole piiratud
            //asub samas projektis 
            Student student = new Student();

            //miks on error
            //koodi ei tohi parandada aga pead aru saama miks on viga
            //kui  tegimst internal classiga siis ei saa teisest 
            //projektist neid esile kutsuda
            //Student2 student2 = new Student2();

            student.Id = 101;
            student.Name = "Test";
            student.Email = "Test@test.com";
            Console.WriteLine("Id = " + student.Id);
            Console.WriteLine("Name = " + student.Name);
            Console.WriteLine("Email = " + student.Email);

            //kasutame protectedstudent classi
            //ProtectedStudents protectedStudents = new ProtectedStudents();
            //protectedStudents.Dosomething();
            //ei saa kasutada kuna asub teises classis aga samas projektis 
            //teha Program.cs meetod nimega DosomethingInPrrogramClass
            //ja kutsuge see esile Program meetodis
            Program program = new Program();
            program.DosomethingInProgramClass();

            Program programs = new Program();
            Console.WriteLine(programs.privateProtectedCs); 
            //soovime kasutada privateprotcedstudent classis olevat
            //    meetodit ja kutsuda see esile Main meetodis
            var privates = new PrivateProtectedStudent();
            //kui asub samas classis siis saab kasutada,
            //aga teises classis olevat ei saa
            //privates.Privateprotectedstudent = "aasdas";

            //sealed Classi kasutamine
            Console.WriteLine("----------Sealed class-----------");
            var sc = new SealedStudent();
            sc.Id = 123;
            sc.Name = "Test";
            sc.Email = "Sealedtest@sealed.com";
            Console.WriteLine($"Id on {sc.Id}, Name on {sc.Name} ja Email on {sc.Email}");

        }
        protected void DosomethingInProgramClass()
        {
            Console.WriteLine("DosomethingInProgramClass");
        }

        private protected string privateProtectedCs = "PrivateProtectedInProgramClass";
    }
}

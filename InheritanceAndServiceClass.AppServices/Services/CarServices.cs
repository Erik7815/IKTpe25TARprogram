using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceAndServiceClass.Core.ServiceInterface;

namespace InheritanceAndServiceClass.AppServices.Services
{
    public class CarServices : ICarServices
    {
        public void GetData()
        {
            Console.WriteLine("Car Services");
        }
        public void PostData()
        {
            Console.WriteLine("andmed on edukalt salvestatud");
        }
        public void PutData()
        {
            Console.WriteLine("Andmed on edukalt uuendatud");
        }
        public void DeleteData()
        {
            Console.WriteLine("Andmed on edukalt kustutatud");
        }
    }
}


using System;
using InheritanceAndServiceClass.AppServices.Services;
using InheritanceAndServiceClass.Core.ServiceInterface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;



namespace InheritanceAndServiceClass
{
    internal class Program
    {
        private readonly ICarServices _carServices;

        public Program
            (
                ICarServices carServices
            )
        {
            _carServices = carServices;
        }

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICarServices, CarServices>();

            Console.WriteLine("Hello, World Switch!");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var app = builder.Build();
                    using (var scope = app.Services.CreateScope())
                    {
                        var carServices = scope.ServiceProvider.GetRequiredService<ICarServices>();
                        var program = new Program(carServices);
                        program.GetAsync();
                    }
                    break;
                    case 2:
                    var apps = builder.Build();
                    using (var scope = apps.Services.CreateScope())
                    {
                        var carServices = scope.ServiceProvider.GetRequiredService<ICarServices>();
                        var program = new Program(carServices);
                        program.SaveAsync();
                        break;
                    }
                case 3:
                    var aps = builder.Build();
                    using (var scope = aps.Services.CreateScope())
                    {
                        var carServices = scope.ServiceProvider.GetRequiredService<ICarServices>();
                        var program = new Program(carServices);
                        program.SaveAsync();
                        break;
                    }

                case 4:
                    var ap = builder.Build();
                    using (var scope = ap.Services.CreateScope())
                    {
                        var carServices = scope.ServiceProvider.GetRequiredService<ICarServices>();
                        var program = new Program(carServices);
                        program.EraseData();
                        break;
                    }
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        public IActionResult GetAsync()
        {
            _carServices.GetData();

            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }
        public IActionResult SaveAsync()
        {
            _carServices.PostData();
            return View();
        }
        public IActionResult UpdateData()
        {
            _carServices.PostData();
            return View();
        }
        public IActionResult EraseData()
        {
            _carServices.DeleteData();
            return View();
        }
    }
}
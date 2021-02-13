using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
        }

        private static void CarTest()
        {
             CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 90, Description = "Volkswagen Polo", Id = 1, ModelYear = "2016" });
            //carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 120, Description = "Ford Focus", Id = 2, ModelYear = "2018" });
            //carManager.Add(new Car { BrandId = 2, ColorId = 3, DailyPrice = 50, Description = "Toyota Yaris", Id = 3, ModelYear = "2017" });
            //carManager.Add(new Car { BrandId = 3, ColorId = 4, DailyPrice = 200, Description = "Tesla Model X", Id = 4, ModelYear = "2013" });
            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine(car.BrandName+"/"+car.ColorName+"/"+car.DailyPrice+"/"+car.Description);
            }
        }
    }
}

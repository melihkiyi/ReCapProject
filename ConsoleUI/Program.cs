using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetCarsByColorId(2))
            {
                //Console.WriteLine(car.ColorId);
            }
            carManager.Add(new Car {Id=23,BrandId=2,ColorId=3,ModelYear=2020,DailyPrice=500,Description="Automatic"});
            //carManager.Delete(new Car { Id = 23 });
        }
    }
}

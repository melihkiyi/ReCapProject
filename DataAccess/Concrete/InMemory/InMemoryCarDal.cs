using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2010, DailyPrice=80000, Description="Automatic"},
                new Car{Id=2, BrandId=1, ColorId=2, ModelYear=2005, DailyPrice=50000, Description="Manual"},
                new Car{Id=3, BrandId=2, ColorId=3, ModelYear=2020, DailyPrice=100000, Description="Automatic"},
                new Car{Id=4, BrandId=2, ColorId=1, ModelYear=2012, DailyPrice=87500, Description="Manual"},
                new Car{Id=5, BrandId=3, ColorId=3, ModelYear=1999, DailyPrice=27000, Description="Manual"},
                new Car{Id=1, BrandId=3, ColorId=2, ModelYear=2021, DailyPrice=320000, Description="Automatic"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(p => p.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
        }
    }
}

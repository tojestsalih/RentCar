using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car
                {
                    CarId = 1, BrandId = 1, ColorId = 3, DailyPrice = 99, Description = "VW Polo", ModelYear = "2015"
                },
                new Car
                {
                    CarId = 2, BrandId = 1, ColorId = 5, DailyPrice = 199, Description = "Toyota Corolla",
                    ModelYear = "2015"
                },
                new Car
                {
                    CarId = 3, BrandId = 2, ColorId = 7, DailyPrice = 1500, Description = "Tesla Model X",
                    ModelYear = "2015"
                },
                new Car
                {
                    CarId = 4, BrandId = 3, ColorId = 12, DailyPrice = 700, Description = "Audi A8", ModelYear = "2015"
                }
            };
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _car.SingleOrDefault(p => p.CarId == car.CarId);
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;
            CarToUpdate.CarId = car.CarId;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;

        }

        public void Delete(Car car)
        {
            Car CarToDelete = _car.SingleOrDefault(p => p.CarId == car.CarId);
            _car.Remove(CarToDelete);
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
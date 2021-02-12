using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }
        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _iCarDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _iCarDal.GetAll(p => p.BrandId == id);
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _iCarDal.Add(car);
            }
            else
            {
                Console.WriteLine("Car description must contain at least 2 characters and DailyPrice > 0");
            }
        }
    }
}
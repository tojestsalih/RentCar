using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == id));
        }


        public IResult UpdateCar(Car car)
        {
            _iCarDal.Update(car);
            return new SuccessResult(Messages.EntityUpdated);
        }

        public IResult DeleteCar(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(Messages.EntityDelete);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
        }

        public IResult AddCar(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _iCarDal.Add(car);
                return new SuccessResult(Messages.EntityAdded);
            }

            Console.WriteLine("Car description must contain at least 2 characters and DailyPrice > 0");
            return new ErrorResult(Messages.EntityNameInvalid);
        }
    }
}
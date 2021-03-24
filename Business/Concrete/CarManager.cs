using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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

        [CacheRemoveAspect("ICarService.Get")]
        public IResult UpdateCar(Car car)
        {
            _iCarDal.Update(car);
            return new SuccessResult(Messages.EntityUpdated);
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult DeleteCar(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(Messages.EntityDelete);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailById(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(c => c.BrandId == brandId));
        }


        public IDataResult<List<Car>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.Id == carId));
        }

        

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult AddCar(Car car)
        {
            _iCarDal.Add(car);
            return new SuccessResult(Messages.EntityAdded);
        }
    }
}
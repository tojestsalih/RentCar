using System;
using System.Collections.Generic;
using System.IO;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal iCarImageDal)
        {
            _carImageDal = iCarImageDal;
        }



        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }



        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }



        public IDataResult<List<CarImage>> GetByImageId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.ImageId == id));
        }



        [ValidationAspect(typeof(CarImageValidator))]
        public IResult AddImage(IFormFile file, CarImage image)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(image.CarId));

            if (result != null)
            {
                return result;
            }

            image.ImagePath = FileHelper.Add(file);
            image.Date = DateTime.Now;
            _carImageDal.Add(image);
            return new SuccessResult();
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult UpdateImage(IFormFile file, CarImage image)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(image.CarId));

            if (result != null)
            {
                return result;
            }

            var carImg = _carImageDal.Get(c => c.ImageId == image.ImageId);
            carImg.Date = DateTime.Now;
            carImg.ImagePath = FileHelper.Add(file);
            FileHelper.Delete(image.ImagePath);
            _carImageDal.Update(image);
            return new SuccessResult("image" + Messages.EntityUpdated);

        }


        public IResult DeleteImage(CarImage image)
        {
            //var result = _carImageDal.Get(i => i.ImageId == image.ImageId);
            IResult result = BusinessRules.Run(DeleteCarImage(image));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(image);
            return new SuccessResult();
        }


        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImagesLimitExceeded);
            }

            return new SuccessResult();
        }

        private IResult DeleteCarImage(CarImage image)
        {
            try
            {
                File.Delete(image.ImagePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return new SuccessResult();
        }
    }
}
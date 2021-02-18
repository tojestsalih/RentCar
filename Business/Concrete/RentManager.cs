using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {
        private IRentalDal _iRentalDal;

        public RentManager(IRentalDal iRentalDal)
        {
            _iRentalDal = iRentalDal;

        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll());
        }

        public IResult AddRental(Rental rental)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = context.Cars.Any(c => c.Id == rental.CarId && c.Available);
                if (result)
                {
                    Console.WriteLine("Eklendi");
                    _iRentalDal.Add(rental);
                    return new SuccessResult(Messages.EntityAdded);
                }
                else
                {
                    Console.WriteLine("Eklenemedi");
                    return new ErrorResult(Messages.EntityNameInvalid);
                }

            }

        }

        public IResult UpdateRental(Rental rental)
        {
            _iRentalDal.Update(rental);
            return new SuccessResult(Messages.EntityUpdated);
        }

        public IResult DeleteRental(Rental rental)
        {
            _iRentalDal.Delete(rental);
            return new SuccessResult(Messages.EntityDelete);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_iRentalDal.GetRentalDetails());
        }
    }
}
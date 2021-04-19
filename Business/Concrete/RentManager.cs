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
    public class RentalManager : IRentalService
    {
        private IRentalDal _iRentalDal;

        public RentalManager(IRentalDal iRentalDal)
        {
            _iRentalDal = iRentalDal;

        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(r => r.RentId == id));
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(r => r.CustomerId == customerId));
        }

        public IResult AddRent(Rental rental)
        {
            _iRentalDal.Add(rental);
            return new SuccessResult(Messages.EntityAdded);

        }

        public IResult UpdateRent(Rental rental)
        {
            _iRentalDal.Update(rental);
            return new SuccessResult(Messages.EntityUpdated);
        }

        public IResult DeleteRent(Rental rental)
        {
            _iRentalDal.Delete(rental);
            return new SuccessResult(Messages.EntityDelete);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_iRentalDal.GetRentalDetails());
        }

        public IResult CheckIsAvailable(Rental rental)
        {
            if (_iRentalDal.IsCarAvailableInGivenStatus(rental.CarId, rental.RentDate, rental.ReturnDate))
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        public IDataResult<List<RentalDetailDto>> GetDetailByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(
                _iRentalDal.GetRentalDetails(r => r.CustomerId == customerId));
        }
    }
}
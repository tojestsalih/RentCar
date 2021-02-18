using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentManager:IRentService
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
            _iRentalDal.Add(rental);
            return new SuccessResult(Messages.EntityAdded);
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
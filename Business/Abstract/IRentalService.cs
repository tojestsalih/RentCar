using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetById(int id);
        IDataResult<List<Rental>> GetByCarId(int carId);
        IDataResult<List<Rental>> GetByCustomerId(int customerId);
        IResult AddRent(Rental rental);
        IResult UpdateRent(Rental rental);
        IResult DeleteRent(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult CheckIsAvailable(Rental rental);
        IDataResult<List<RentalDetailDto>> GetDetailByCustomerId(int customerId);
    }
}
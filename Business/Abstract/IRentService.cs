using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetById(int id);
        IResult AddRent(Rental rental);
        IResult UpdateRent(Rental rental);
        IResult DeleteRent(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
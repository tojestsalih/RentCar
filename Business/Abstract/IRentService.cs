using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentService
    {
        IDataResult<List<Rental>> GetAll();
        IResult AddRental(Rental rental);
        IResult UpdateRental(Rental rental);
        IResult DeleteRental(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
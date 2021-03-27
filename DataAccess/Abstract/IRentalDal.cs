using System;
using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        bool IsCarAvailableInGivenStatus(int carId, DateTime rentDate, DateTime? returnDate);
        List<RentalDetailDto> GetRentalDetails();
    }
}
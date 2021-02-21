using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetById(int id);
        IResult AddBrand(Brand brand);
        IResult UpdateBrand(Brand brand);
        IResult DeleteBrand(Brand brand);

    }
}
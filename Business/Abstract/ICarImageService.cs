using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
        IDataResult<List<CarImage>> GetByImageId(int id);
        IResult AddImage(Car car);
        IResult UpdateImage(Car car);
        IResult DeleteImage(Car car);
    }
}
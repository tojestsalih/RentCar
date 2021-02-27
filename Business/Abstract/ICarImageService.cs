using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
        IDataResult<List<CarImage>> GetByImageId(int id);
        IResult AddImage(IFormFile file , CarImage image);
        IResult UpdateImage(IFormFile file, CarImage image);
        IResult DeleteImage(CarImage image);
    }
}
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IResult AddCar(Car car);
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetail();
    }
}
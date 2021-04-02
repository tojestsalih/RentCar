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
        IDataResult<List<Car>> GetByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailByColor(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailByBrandAndColor(int brandId, int colorId);
    }
}
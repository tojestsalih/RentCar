using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByColorId(int id);
        List<Car> GetCarsByBrandId(int id);
        void Add(Car car);
    }
}
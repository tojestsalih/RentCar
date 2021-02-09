using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car
                {
                    Id = 1, BrandId = 1, ColorId = 3, DailyPrice = 99, Description = "VW Polo", ModelYear = "2015"
                },
                new Car
                {
                    Id = 2, BrandId = 1, ColorId = 5, DailyPrice = 199, Description = "Toyota Corolla",
                    ModelYear = "2015"
                },
                new Car
                {
                    Id = 3, BrandId = 2, ColorId = 7, DailyPrice = 1500, Description = "Tesla Model X",
                    ModelYear = "2015"
                },
                new Car
                {
                    Id = 4, BrandId = 3, ColorId = 12, DailyPrice = 700, Description = "Audi A8", ModelYear = "2015"
                }
            };
        }
        public List<Car> GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _car.SingleOrDefault(p => p.Id == car.Id);
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;
            CarToUpdate.Id = car.Id;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;

        }

        public void Delete(Car car)
        {
            Car CarToDelete = _car.SingleOrDefault(p => p.Id == car.Id);
            _car.Remove(CarToDelete);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {

        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             join brand in context.Brands
                             on c.BrandId equals brand.BrandId

                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 DailyPrice = c.DailyPrice,
                                 BrandName = brand.BrandName,
                                 CarId = c.Id,
                                 ColorName = color.ColorName,
                                 Available = c.Available,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}
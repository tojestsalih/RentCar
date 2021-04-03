using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result =
                    from c in filter == null ? context.Cars : context.Cars.Where(filter)
                    join color in context.Colors
                    on c.ColorId equals color.ColorId
                    join brand in context.Brands
                    on c.BrandId equals brand.BrandId

                    select new CarDetailDto
                    {
                        Description = c.Description,
                        DailyPrice = c.DailyPrice,
                        BrandName = brand.BrandName,
                        CarId = c.CarId,
                        ColorName = color.ColorName,
                        Available = c.Available,
                        ModelYear = c.ModelYear,
                        BrandId = brand.BrandId,
                        ColorId = color.ColorId
                    };
                return result.ToList();
            }
        }

        
    }
}
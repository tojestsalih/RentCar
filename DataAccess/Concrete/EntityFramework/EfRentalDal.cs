using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars 
                             on rental.CarId equals car.Id
                             join customer in context.Customers 
                             on rental.CustomerId equals customer.Id
                             join brand in context.Brands
                             on car.BrandId equals  brand.BrandId
                             join color in context.Colors 
                             on car.ColorId equals color.ColorId
                             join user in context.Users
                             on customer.UserId equals user.Id


                             select new RentalDetailDto
                             {
                                 CarId = car.Id,
                                 RentId = rental.RentId,
                                 CustomerId = customer.Id,
                                 FirstName = user.FirstName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 BrandName = brand.BrandName,
                                 ModelYear = car.ModelYear,
                                 ColorName = color.ColorName,
                                 Description = car.Description,
                                 Email = user.Email,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();

            }
        }
    }
}
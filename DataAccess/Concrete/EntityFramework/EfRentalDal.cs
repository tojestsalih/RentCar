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
                             join user in context.Users
                             on rental.UserId equals user.Id
                             join customer in context.Customers 
                             on rental.UserId equals customer.UserId
                             join brand in context.Brands
                             on car.BrandId equals  brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId


                             select new RentalDetailDto
                             {
                                 CarId = car.Id,
                                 RentId = rental.RentId,
                                 UserId = user.Id,
                                 FirstName = user.FirstName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 BrandName = brand.BrandName,
                                 ModelYear = car.ModelYear,
                                 ColorName = color.ColorName,
                                 DescriptionModel = car.Description
                             };
                return result.ToList();

            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,RentCarContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Customers
                    join user in context.Users
                        on c.UserId equals user.Id
                    select new CustomerDetailDto()
                    {
                        Id = c.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        CompanyName = c.CompanyName
                    };
                return result.ToList();
            }
            
        }
    }
}
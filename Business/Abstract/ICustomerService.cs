using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetByUserId(int userId);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetail();
        IResult AddCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
    }
}
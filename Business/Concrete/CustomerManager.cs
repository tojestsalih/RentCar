using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _iCustomerDal;

        public CustomerManager(ICustomerDal iCustomerDal)
        {
            _iCustomerDal = iCustomerDal;
        }
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_iCustomerDal.GetAll());
        }
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_iCustomerDal.GetCustomerDetails());
        }

        public IResult AddCustomer(Customer customer)
        {
            _iCustomerDal.Add(customer);
            return new SuccessResult(Messages.EntityAdded);

        }

        public IResult UpdateCustomer(Customer customer)
        {
            _iCustomerDal.Update(customer);
            return new SuccessResult(Messages.EntityUpdated);
        }

        public IResult DeleteCustomer(Customer customer)
        {
            _iCustomerDal.Delete(customer);
            return new SuccessResult(Messages.EntityDelete);
        }
    }
}
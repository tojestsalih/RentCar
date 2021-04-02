using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IDataResult<List<Payment>> GetAll();
        IDataResult<List<Payment>> GetById(int id);
        IResult Add(Payment payment);
        IResult Update(Payment payment);
        IResult Delete(Payment payment);
    }
}
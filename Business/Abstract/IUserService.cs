using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<User>> GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetById(int id);
        IResult AddUser(User user);
        IResult UpdateUser(User user);
        IResult DeleteUser(User user);
        
    }
}
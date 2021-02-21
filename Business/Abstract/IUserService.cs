using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetById(int id);
        IResult AddUser(User user);
        IResult UpdateUser(User user);
        IResult DeleteUser(User user);
        
    }
}
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult AddUser(User user);
        IResult UpdateUser(User user);
        IResult DeleteUser(User user);
        
    }
}
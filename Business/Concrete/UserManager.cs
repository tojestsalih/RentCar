using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;


namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _iUserDal;

        public UserManager(IUserDal iUserDal)
        {
            _iUserDal = iUserDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_iUserDal.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_iUserDal.Get(u => u.Email == email));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_iUserDal.GetAll());
        }

        public IDataResult<List<User>> GetById(int id)
        {
            return new SuccessDataResult<List<User>>(_iUserDal.GetAll(u => u.Id == id));
        }

        public IResult AddUser(User user)
        {
            _iUserDal.Add(user);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult UpdateUser(User user)
        {
            _iUserDal.Update(user);
            return new SuccessResult(Messages.EntityUpdated);
        }

        public IResult DeleteUser(User user)
        {
            _iUserDal.Delete(user);
            return new SuccessResult(Messages.EntityDelete);
        }
    }
}
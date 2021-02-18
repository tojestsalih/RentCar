﻿using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _iUserDal;

        public UserManager(IUserDal iUserDal)
        {
            _iUserDal = iUserDal;
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_iUserDal.GetAll());
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
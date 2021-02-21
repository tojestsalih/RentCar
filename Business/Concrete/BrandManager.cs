using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _iBrandDal;

        public BrandManager(IBrandDal iBrandDal)
        {
            _iBrandDal = iBrandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_iBrandDal.GetAll());
        }

        public IDataResult<List<Brand>> GetById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_iBrandDal.GetAll(p => p.BrandId == id));
        }

        public IResult AddBrand(Brand brand)
        {
            _iBrandDal.Add(brand);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult UpdateBrand(Brand brand)
        {
            _iBrandDal.Update(brand);
            return new SuccessResult(Messages.EntityUpdated);
        }

        public IResult DeleteBrand(Brand brand)
        {
            _iBrandDal.Delete(brand);
            return new SuccessResult(Messages.EntityDelete);
        }
    }
}
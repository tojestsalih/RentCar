using System.Collections.Generic;
using Business.Abstract;
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
        public List<Brand> GetAll()
        {
            return _iBrandDal.GetAll();
        }


        public void Add(Brand brand)
        {
            _iBrandDal.Add(brand);
        }
    }
}
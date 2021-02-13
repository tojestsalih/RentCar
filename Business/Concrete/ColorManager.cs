using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        private IColorDal _iColorDal;

        public ColorManager(IColorDal iColorDal)
        {
            _iColorDal = iColorDal;
        }
        public List<Color> GetAll()
        {
            return _iColorDal.GetAll();
        }

        public void Add(Color color)
        {
            _iColorDal.Add(color);
        }
    }
}
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_iColorDal.GetAll());
        }

        public IDataResult<List<Color>> GetById(int id)
        {
            return new SuccessDataResult<List<Color>>(_iColorDal.GetAll(p => p.ColorId == id));
        }

        public IResult AddColor(Color color)
        {
            _iColorDal.Add(color);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult UpdateColor(Color color)
        {
            _iColorDal.Update(color);
            return new SuccessResult(Messages.EntityUpdated);
        }

        public IResult DeleteColor(Color color)
        {
            _iColorDal.Delete(color);
            return new SuccessResult(Messages.EntityDelete);
        }
    }
}
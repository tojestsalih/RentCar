using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        [ValidationAspect(typeof(ColorValidator))]
        public IResult AddColor(Color color)
        {
            IResult iResult = BusinessRules.Run(CheckNameAlreadyExits(color.ColorName));

            if (iResult != null)
            {
                return iResult;
            }

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

        private IResult CheckNameAlreadyExits(string colorName)
        {
            var result = _iColorDal.GetAll(c=>c.ColorName == colorName).Any();

            if (result)
            {
                return new ErrorResult(Messages.NameAlreadyExist);
            }

            return new SuccessResult();
        }
    }
}
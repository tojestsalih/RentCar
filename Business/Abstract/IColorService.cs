using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<List<Color>> GetById(int id);
        IResult AddColor(Color color);
        IResult UpdateColor(Color color);
        IResult DeleteColor(Color color);
    }
}
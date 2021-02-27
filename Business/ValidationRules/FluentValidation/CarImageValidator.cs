using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator:AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(i => i.CarId).NotNull();
            RuleFor(i => i.ImageId).NotNull();
        }
    }
}
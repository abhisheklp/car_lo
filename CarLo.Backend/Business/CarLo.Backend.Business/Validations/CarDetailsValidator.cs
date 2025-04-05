using CarLo.Backend.Business.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarLo.Backend.Business.Validations
{
    public class CarDetailsValidator : AbstractValidator<CarDetailsDTO>
    {
        public CarDetailsValidator()
        {
            RuleFor(c => c.CarBrandName).NotEmpty().MaximumLength(15);

            RuleFor(c => c.CarModelName).NotEmpty().MaximumLength(15);

            RuleFor(c => c.CarDescription).NotEmpty().MaximumLength(255);

            RuleFor(c => c.RentalPrice).NotEmpty();

            RuleFor(c => c.CarAvailability).NotEmpty();

            RuleFor(c => c.CarCategoryEntityId).NotEmpty();
        }
    }
}

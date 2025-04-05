using CarLo.Backend.Business.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarLo.Backend.Business.Validations
{
    public class CarCategoryValidator : AbstractValidator<CarCategoryDTO>
    {
        public CarCategoryValidator()
        {
            RuleFor(c => c.CarCategoryName).NotEmpty().MaximumLength(10);

            RuleFor(c => c.CarCategoryDescription).NotEmpty().MaximumLength(255);
        }
    }
}

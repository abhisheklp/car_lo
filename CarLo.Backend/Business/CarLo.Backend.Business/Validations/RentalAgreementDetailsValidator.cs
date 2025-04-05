using CarLo.Backend.Business.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarLo.Backend.Business.Validations
{
    public class RentalAgreementDetailsValidator : AbstractValidator<RentalAgreementDTO>
    {
        public RentalAgreementDetailsValidator()
        {
            RuleFor(r => r.FullName).NotEmpty().MaximumLength(50);

            RuleFor(r => r.PhoneNo).NotEmpty().Length(10);

            RuleFor(r => r.Address).NotEmpty().MaximumLength(255);

            RuleFor(r => r.NoOfDays).NotEmpty().InclusiveBetween(1, 15);

            RuleFor(r => r.LicenseNo).NotEmpty();

            RuleFor(r => r.CarDetailsEntityId).NotEmpty();
        }
    }
}

using CarLo.Backend.Business.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarLo.Backend.Business.Validations
{
    public class ReturnRequestValidator : AbstractValidator<ReturnRequestDTO>
    {
        public ReturnRequestValidator()
        {
            //RuleFor(r => r.RentalAgreementEntityId).NotEmpty();
        }
    }
}

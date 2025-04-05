using CarLo.Backend.Business.DTO.AccountDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarLo.Backend.Business.Validation.AccountValidator
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email address.");

            RuleFor(l => l.Password).NotEmpty().WithMessage("Password is required.");
        }
    }
}

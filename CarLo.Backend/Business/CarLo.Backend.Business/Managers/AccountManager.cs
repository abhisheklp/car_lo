using AutoMapper;
using FluentValidation.Results;
using CarLo.Backend.Business.DTO.AccountDTO;
using CarLo.Backend.Business.Managers.Interface;
using CarLo.Backend.Business.Validation.AccountValidator;
using CarLo.Backend.DAL.Entities.AccountEntity;
using CarLo.Backend.DAL.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.Business.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountManager(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpDTO user)
        {
            SignupValidator validator = new SignupValidator();
            ValidationResult result = validator.Validate(user);

            if(result.IsValid)
            {
                var entity = _mapper.Map<SignUpEntity>(user);
                var respose = await _accountRepository.CreateUserAsync(entity);
                return respose;
            }
            return IdentityResult.Failed();
        }

        public async Task<string> PasswordLoginAsync(LoginDTO user)
        {
            LoginValidator validator = new LoginValidator();
            ValidationResult result = validator.Validate(user);

            if(result.IsValid)
            {
                var entity = _mapper.Map<LoginEntity>(user);
                var respose = await _accountRepository.PasswordLoginAsync(entity);
                return respose;
            }
            return null;
        }

        public async Task LogOutAsync()
        {
            await _accountRepository.LogOutAsync();
        }

    }
}

using CarLo.Backend.DAL.Entities.AccountEntity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarLo.Backend.DAL.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpEntity signUpData);
        Task<string> PasswordLoginAsync(LoginEntity loginData);
        Task LogOutAsync();
    }
}

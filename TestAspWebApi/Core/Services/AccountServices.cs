using Core.Contract.Repository_Contract;
using Core.Contract.Services_Contract;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Contract.Services_Contract.CustomSignInResult> SignInAsync(SignIn signIn)
        {
            var token = await _accountRepository.SignInAsync(signIn);

            if (!string.IsNullOrEmpty(token))
            {
                return new CustomSignInResult
                {
                    Succeeded = true,
                    Token = token
                };
            }

            return new CustomSignInResult
            {
                Succeeded = false,
                Errors = new[] { "Đăng nhập thất bại." }
            };
        }

        public async Task<CustomSignUpResult> SignUpAsync(SignUp signUp)
        {
            var result = await _accountRepository.SignUpAsync(signUp);

            return new CustomSignUpResult
            {
                Succeeded = result.Succeeded,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
    }
}

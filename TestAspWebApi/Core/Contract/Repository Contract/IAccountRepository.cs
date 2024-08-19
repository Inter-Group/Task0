using Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract.Repository_Contract
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUp sign);
        public Task<string> SignInAsync(SignIn sign);
    }
}

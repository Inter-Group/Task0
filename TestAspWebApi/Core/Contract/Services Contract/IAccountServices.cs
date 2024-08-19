using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract.Services_Contract
{
    public interface IAccountService
    {
        Task<CustomSignUpResult> SignUpAsync(SignUp signUp);
        Task<CustomSignInResult> SignInAsync(SignIn signIn);
    }

    public class CustomSignUpResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }

    public class CustomSignInResult
    {
        public bool Succeeded { get; set; }
        public string? Token { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}

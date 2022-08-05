using CustomerCRM.Core.Entities;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Infrastructure.Repository
{
    public class AccountRepositoryAsync : IAccountRepositoryAsync
    {
        /* We do not need DbContext here why ?
         * Because we will have Microsoft Identity to work with it.
         * "UserManager" will handle user login and password.
         * We should create our fields private readonly for security purposes (everywhere).
         */
        // for sign up
        private readonly UserManager<ApplicationUser> userManager;
        // for sign in
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountRepositoryAsync(UserManager<ApplicationUser> m, SignInManager<ApplicationUser> s)
        {
            signInManager = s;
            userManager = m;
        }
        public Task<IdentityResult> SignUpAsync(SignUpModel user)
        {
            //we do not specify password here because we will encrypt it.

            ApplicationUser appUser = new ApplicationUser();
            appUser.FirstName = user.FirstName;
            appUser.LastName = user.LastName;
            appUser.Email = user.Email;
            appUser.UserName = user.Email;

            // Password encryption done by Microsoft Identity.
            return userManager.CreateAsync(appUser, user.Password);
            
            //return Task.FromResult(IdentityResult.Success);
        }

        public Task<SignInResult> LoginAsync(SignInModel model)
        {
            // Email, Password, Remember the info, LockoutOnFailure
            return signInManager.PasswordSignInAsync(model.Email, model.Password, model.Remember, false);
        }
    }
}

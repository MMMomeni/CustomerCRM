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

        private readonly UserManager<ApplicationUser> userManager;
        public AccountRepositoryAsync(UserManager<ApplicationUser> m)
        {
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
    }
}

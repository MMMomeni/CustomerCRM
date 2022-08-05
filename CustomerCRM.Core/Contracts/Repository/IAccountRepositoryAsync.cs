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
    public interface IAccountRepositoryAsync
    {
        Task<IdentityResult> SignUpAsync(SignUpModel user);
        Task<SignInResult> LoginAsync(SignInModel model);

    }
}

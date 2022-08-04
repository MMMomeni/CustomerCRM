using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;
using CustomerCRM.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Infrastructure.Service
{
    public class AccountServiceAsync : IAccountServiceAsync
    {
        private readonly IAccountRepositoryAsync accountRepositoryAsync;
        public AccountServiceAsync(IAccountRepositoryAsync accountRepositoryAsync)
        {
            this.accountRepositoryAsync = accountRepositoryAsync;
        }

        public Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            return accountRepositoryAsync.SignUpAsync(model);
        }
    }
}

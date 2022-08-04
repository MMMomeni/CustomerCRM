using CustomerCRM.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Infrastructure.Data
{
    /* we changed "DbContext" to "IdentityDbContext" when decided to
     * implement user also DbContext will be inhereted automatically
     * we also could pass IdentityUser instead of name of ApplicatonUser
     * if we did not want to create a new class for user
     */
    public class CustomerCrmDbContext:IdentityDbContext<ApplicationUser>
    {

        /*Why we are doing this ? because our db connection string is in WebAppMVC project and we are in
         the Infrastructore*/
        public CustomerCrmDbContext(DbContextOptions<CustomerCrmDbContext> options) : base(options)
        {

        }

        public DbSet<Region> Region { get; set; }
        public DbSet<Shipper> Shipper { get; set; }
    }
}

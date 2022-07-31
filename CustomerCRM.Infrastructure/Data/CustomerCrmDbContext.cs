using CustomerCRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Infrastructure.Data
{
    public class CustomerCrmDbContext:DbContext
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

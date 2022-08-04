using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Core.Entities
{ 
    public class ApplicationUser: IdentityUser
    {
        /* Why did we create this class ?
         * because "IdentityUser" gives us all the properties we wanted except FirstName and LastName.
         * We do not need to creat Id because Id automatically will be implemented by "IdentityUser".
         */

        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string LastName { get; set; }
    }
}

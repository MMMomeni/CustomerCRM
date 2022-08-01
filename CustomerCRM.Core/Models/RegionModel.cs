using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CustomerCRM.Core.Entities;

namespace CustomerCRM.Core.Models
{
    public class RegionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Region Name is required")]
        [MaxLength(50, ErrorMessage = "Region Name can be maximum 50 character long")]
        public string Name { get; set; }

    }
}

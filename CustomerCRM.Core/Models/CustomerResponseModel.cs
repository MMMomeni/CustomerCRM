using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomerCRM.Core.Models
{
    public class CustomerResponseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30, ErrorMessage = "Maximum 30 characters are allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30, ErrorMessage = "Maximum 30 characters are allowed")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(80, ErrorMessage = "Maximum 80 characters are allowed")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(20, ErrorMessage = "Maximum 20 characters are allowed")]
        public string City { get; set; }
        public int RegionId { get; set; }
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(20, ErrorMessage = "Maximum 20 characters are allowed")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15, ErrorMessage = "Maximum 15 characters are allowed")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(500, ErrorMessage = "Maximum 500 characters are allowed")]
        public string Photo { get; set; }

        public string RegionName { get; set; }
    }
}

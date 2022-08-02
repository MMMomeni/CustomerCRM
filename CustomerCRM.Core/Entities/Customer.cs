using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerCRM.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Column(TypeName="Varchar(30)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(30)")]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "Varchar(80)")]
        [Required]
        public string Address { get; set; }

        [Column(TypeName = "Varchar(20)")]
        [Required]
        public string City { get; set; }
        public int RegionId { get; set; }
        public int PostalCode { get; set; }

        [Column(TypeName = "Varchar(20)")]
        [Required]
        public string Country { get; set; }

        [Column(TypeName = "Varchar(15)")]
        [Required]
        public string Phone { get; set; }

        [Column(TypeName = "Varchar(500)")]
        [Required]
        public string Photo { get; set; }

        // Navigational property
        public Region Region { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCRM.Core.Entities
{
    public class Shipper
    {
        public int Id { get; set; }

        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Phone { get; set; }
    }
}

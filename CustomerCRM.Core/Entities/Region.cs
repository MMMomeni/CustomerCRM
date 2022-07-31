using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCRM.Core.Entities
{
    public class Region
    {
        public int Id { get; set; }

        [Column(TypeName="varchar(50)")]
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts
{
    public abstract class da_Way
    {
        [Column("id_вида"), Key]
        public  int Id { get; set; }
        [Column("описание")]
        public  string Name { get; set; }

    }
   
}

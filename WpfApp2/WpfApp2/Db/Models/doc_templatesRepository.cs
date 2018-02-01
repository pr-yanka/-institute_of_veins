
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace WpfApp2.Db.Models
{
    [Table("doc_templates")]
    public class doc_templates
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
      
        [Column("TemplateBinary")]
        public Byte[] DocTemplate { set; get; }
    }

    public class doc_templatesRepository : Repository<doc_templates>
    {
        public doc_templatesRepository(DbContext context) : base(context)
        {

        }
    }
}
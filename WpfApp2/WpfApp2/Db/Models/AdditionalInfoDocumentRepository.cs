
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
    //  [Table("дополнительная_информация_документ")]
    [Table("additional_information_document")]
    public class AdditionalInfoDocument
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("document")]
        public Byte[] DocTemplate { set; get; }

      

        [Column("id_doctor")]
        public int DoctorId { set; get; }

    }

    public class AdditionalInfoDocumentRepository : Repository<AdditionalInfoDocument>
    {
        public AdditionalInfoDocumentRepository(DbContext context) : base(context)
        {

        }
    }
}
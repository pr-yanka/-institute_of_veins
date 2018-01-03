
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
    [Table("операции")]
    public class Operation
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("id_пациента")]
        public int PatientId { set; get; }
        [Column("дата_операции")]
        public DateTime Date { set; get; }
        [Column("время_операции")]
        public string Time { set; get; }
        [Column("id_вида_операции")]
        public int OperationTypeId { set; get; }
        [Column("id_вида_анестетика")]
        public int AnestheticId { set; get; }
        [Column("NB!")]
        public string NB { set; get; }
        [Column("отмена_операции")]
        public int? CancleOperation { set; get; }
        [Column("итоги_операции")]
        public int? ResultOperation { set; get; }

    }
    public class OperationRepository : Repository<Operation>
    {
        public OperationRepository(DbContext context) : base(context)
        {

        }
    }
  
}
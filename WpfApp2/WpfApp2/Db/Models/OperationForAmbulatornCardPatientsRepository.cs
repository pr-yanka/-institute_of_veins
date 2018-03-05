using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    [Table("операции_для_амбулаторной_карты_пациенты")]
    public class OperationForAmbulatornCardPatients
    {
        [Column(Order = 0), Key]
        public int id_пациента { set; get; }
        [Column(Order = 1), Key]
        public int id_операции { set; get; }
  
     

      

    }
    public class OperationForAmbulatornCardPatientsRepository : Repository<OperationForAmbulatornCardPatients>
    {
        public OperationForAmbulatornCardPatientsRepository(DbContext context) : base(context)
        {

        }
    }
  
}
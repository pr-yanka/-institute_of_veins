
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using WpfApp2.Messaging;

namespace WpfApp2.Db.Models
{
    //[Table("хирургическое_вмешательство")]  
    [Table("surgery")]
    public class HirurgInterupt : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("name")]
        public string Str { set { _str = value; MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null); OnPropertyChanged(); } get {  return _str; } }

        [Column("date")]
        public DateTime? Date { set { _date = value; MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null); OnPropertyChanged(); } get { if (_date == null) return DateTime.Now; return _date; } }

        [NotMapped]
        private string _str;

        [NotMapped]
        private DateTime? _date;

        public override string ToString()
        {
            return Str;
        }


    }
    public class HirurgInteruptRepository : Repository<HirurgInterupt>
    {
        public HirurgInteruptRepository(DbContext context) : base(context)
        {

        }
    }

}
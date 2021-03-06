﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts
{
    public abstract class LegPartEntries
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("id_way")]
        public virtual int? WayID { get; set; }
        [Column("sub_entry1")] 
        public virtual int EntryId1 { get; set; }
        [Column("sub_entry2")]
        public virtual int? EntryId2 { get; set; }
        [Column("sub_entry3")]
        public virtual int? EntryId3 { get; set; }
        [Column("sub_entry4")]
        public virtual int? EntryId4 { get; set; }
        [Column("sub_entry5")]
        public virtual int? EntryId5 { get; set; }
        [Column("sub_entry6")]
        public virtual int? EntryId6 { get; set; }



        [Column("sub_entry0")]
        public virtual int? EntryId0 { get; set; }
        //[Column("комментарий")]
        //public virtual string Commentary { get; set; }


    }
}

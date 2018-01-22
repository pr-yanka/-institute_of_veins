using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models
{
    public class MySqlContext : DbContext
    {


       

       




        public DbSet<PDSVHipStructure> PDSVHips { get; set; }
        public DbSet<PDSVHipCombo> PDSVCombos { get; set; }
        public DbSet<PDSVHipEntry> PDSVHipEntries { get; set; }
        public DbSet<PDSVHipWay> PDSVHipWay { get; set; }



        public DbSet<СategoryType> СategoryType { get; set; }
        public DbSet<BPVHipWay> BPVHipWay { get; set; }

        public DbSet<Cities> Cities { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Streets> Streets { get; set; }

        public DbSet<BrigadeMedPersonal> BrigadeMedPersonal { get; set; }

        public DbSet<ScientificTitles> ScientificTitles { get; set; }

        public DbSet<ScientificTitleType> ScientificTitleType { get; set; }

        public DbSet<SpecializationType> SpecializationType { get; set; }

        public DbSet<DoctorsSpecializations> DoctorsSpecializations { get; set; }

        public DbSet<MedPersonal> MedPersonal { get; set; }

        public DbSet<Accaunt> Accaunt { get; set; }

        public DbSet<Patology> Patology { get; set; }

        public DbSet<PatologyType> PatologyType { get; set; }

        public DbSet<ReasonsOfCancelOperation> ReasonsOfCancelOperation { get; set; }

        public DbSet<OperationResult> OperationResult { get; set; }

        public DbSet<CancelOperation> CancelOperation { get; set; }

        public DbSet<Examination> Examination { get; set; }

        public DbSet<DiagnosisObs> DiagnosisObs { get; set; }

        public DbSet<Brigade> Brigade { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }

        public DbSet<Operation> Operation { get; set; }
        public DbSet<OperationType> OperationType { get; set; }
        public DbSet<Anestethic> Anestethic { get; set; }
        public DbSet<Doctor> Doctor { get; set; }


        public DbSet<SFSHipStructure> SFSHips { get; }
        public DbSet<SFSHipCombo> SFSCombos { get; }
        public DbSet<SFSHipEntry> SFSHipEntries { get; }

        public DbSet<Analize> Analize { get; set; }
        public DbSet<AnalizeType> AnalizeType { get; set; }
        public DbSet<BPVHipStructure> BPVHipStructures { get; set; }
        public DbSet<BPVHipCombo> BPVHipCombos { get; set; }
        public DbSet<BPVHipEntry> BPVHipEntries { get; set; }
        public DbSet<Metrics> Metrics { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DiagnosisType> DiagnosisTypes { get; set; }
        public DbSet<RecomendationsType> RecomendationsTypes { get; set; }
        public DbSet<ComplainsType> ComplainsTypes { get; set; }




        public DbSet<BPV_TibiaStructure> BPV_Tibia { get; set; }
        public DbSet<BPV_TibiaCombo> BPV_TibiaCombos { get; set; }
        public DbSet<BPV_TibiaEntry> BPV_TibiaEntries { get; set; }

        public DbSet<Perforate_hipStructure> Perforate_hip { get; set; }
        public DbSet<Perforate_hipCombo> Perforate_hipCombos { get; set; }
        public DbSet<Perforate_hipEntry> Perforate_hipEntries { get; set; }



        public DbSet<ZDSVStructure> ZDSV { get; set; }
        public DbSet<ZDSVCombo> ZDSVCombos { get; set; }
        public DbSet<ZDSVEntry> ZDSVEntries { get; set; }



        public MySqlContext() : base("server=localhost;user=root;database=med_db;password=22222;")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perforate_hipCombo>()
              .HasRequired<Perforate_hipStructure>(s => s.Str1).WithMany(g => g.BPVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<Perforate_hipCombo>()
                .HasOptional<Perforate_hipStructure>(s => s.Str2).WithMany(g => g.BPVs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<Perforate_hipCombo>()
                .HasOptional<Perforate_hipStructure>(s => s.Str3).WithMany(g => g.BPVs3).HasForeignKey<int?>(s => s.IdStr3);

            modelBuilder.Entity<Perforate_hipCombo>()
                .HasOptional<Perforate_hipStructure>(s => s.Str4).WithMany(g => g.BPVs4).HasForeignKey<int?>(s => s.IdStr4);

            modelBuilder.Entity<Perforate_hipCombo>()
                .HasOptional<Perforate_hipStructure>(s => s.Str5).WithMany(g => g.BPVs5).HasForeignKey<int?>(s => s.IdStr5);

            modelBuilder.Entity<Perforate_hipEntry>()
                .HasRequired<Perforate_hipStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);

           
            modelBuilder.Entity<Perforate_hipEntryFull>()
            .HasRequired<Perforate_hipEntry>(s => s.Perforate_hipEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.Perforate_hipEntryId1);
            modelBuilder.Entity<Perforate_hipEntryFull>()
            .HasRequired<Perforate_hipEntry>(s => s.Perforate_hipEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int>(s => s.Perforate_hipEntryId2);

            modelBuilder.Entity<Perforate_hipEntryFull>()
            .HasRequired<Perforate_hipEntry>(s => s.Perforate_hipEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int>(s => s.Perforate_hipEntryId3);

            modelBuilder.Entity<Perforate_hipEntryFull>()
            .HasRequired<Perforate_hipEntry>(s => s.Perforate_hipEntry4).WithMany(g => g.EntriesFull4).HasForeignKey<int>(s => s.Perforate_hipEntryId4);

            modelBuilder.Entity<Perforate_hipEntryFull>()
            .HasRequired<Perforate_hipEntry>(s => s.Perforate_hipEntry5).WithMany(g => g.EntriesFull5).HasForeignKey<int>(s => s.Perforate_hipEntryId5);










            modelBuilder.Entity<BPV_TibiaCombo>()
              .HasRequired<BPV_TibiaStructure>(s => s.Str1).WithMany(g => g.BPVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<BPV_TibiaCombo>()
                .HasOptional<BPV_TibiaStructure>(s => s.Str2).WithMany(g => g.BPVs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<BPV_TibiaCombo>()
                .HasOptional<BPV_TibiaStructure>(s => s.Str3).WithMany(g => g.BPVs3).HasForeignKey<int?>(s => s.IdStr3);

            modelBuilder.Entity<BPV_TibiaCombo>()
              .HasOptional<BPV_TibiaStructure>(s => s.Str4).WithMany(g => g.BPVs4).HasForeignKey<int?>(s => s.IdStr4);

            modelBuilder.Entity<BPV_TibiaEntry>()
                .HasRequired<BPV_TibiaStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);


            modelBuilder.Entity<BPV_TibiaEntryFull>()
            .HasRequired<BPV_TibiaEntry>(s => s.BPV_TibiaEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.BPV_TibiaEntryId1);
            
            modelBuilder.Entity<BPV_TibiaEntryFull>()
            .HasRequired<BPV_TibiaEntry>(s => s.BPV_TibiaEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int>(s => s.BPV_TibiaEntryId2);

            modelBuilder.Entity<BPV_TibiaEntryFull>()
            .HasRequired<BPV_TibiaEntry>(s => s.BPV_TibiaEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int>(s => s.BPV_TibiaEntryId3);

            modelBuilder.Entity<BPV_TibiaEntryFull>()
            .HasRequired<BPV_TibiaEntry>(s => s.BPV_TibiaEntry4).WithMany(g => g.EntriesFull4).HasForeignKey<int>(s => s.BPV_TibiaEntryId4);





            modelBuilder.Entity<ZDSVCombo>()
              .HasRequired<ZDSVStructure>(s => s.Str1).WithMany(g => g.ZDSVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<ZDSVCombo>()
                .HasOptional<ZDSVStructure>(s => s.Str2).WithMany(g => g.ZDSVs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<ZDSVCombo>()
                .HasOptional<ZDSVStructure>(s => s.Str3).WithMany(g => g.ZDSVs3).HasForeignKey<int?>(s => s.IdStr3);


            modelBuilder.Entity<ZDSVEntry>()
                .HasRequired<ZDSVStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);

         
            modelBuilder.Entity<ZDSVEntryFull>()
            .HasRequired<ZDSVEntry>(s => s.ZDSVEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.ZDSVEntryId1);
            modelBuilder.Entity<ZDSVEntryFull>()
            .HasRequired<ZDSVEntry>(s => s.ZDSVEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int>(s => s.ZDSVEntryId2);

            modelBuilder.Entity<ZDSVEntryFull>()
            .HasRequired<ZDSVEntry>(s => s.ZDSVEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int>(s => s.ZDSVEntryId3);










            modelBuilder.Entity<PDSVHipCombo>()
                .HasRequired<PDSVHipStructure>(s => s.Str1).WithMany(g => g.PDSVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<PDSVHipCombo>()
                .HasOptional<PDSVHipStructure>(s => s.Str2).WithMany(g => g.PDSVs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<PDSVHipCombo>()
                .HasOptional<PDSVHipStructure>(s => s.Str3).WithMany(g => g.PDSVs3).HasForeignKey<int?>(s => s.IdStr3);

          
            modelBuilder.Entity<PDSVHipEntry>()
                .HasRequired<PDSVHipStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);

            modelBuilder.Entity<PDSVHipEntryFull>()
              .HasRequired<PDSVHipWay>(s => s.PDSVHipWay).WithMany(g => g.EntriesFull).HasForeignKey<int>(s => s.PDSVHipWayID);

            modelBuilder.Entity<PDSVHipEntryFull>()
            .HasRequired<PDSVHipEntry>(s => s.PDSVHipEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.PDSVHipEntryId1);
            modelBuilder.Entity<PDSVHipEntryFull>()
            .HasRequired<PDSVHipEntry>(s => s.PDSVHipEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int>(s => s.PDSVHipEntryId2);

            modelBuilder.Entity<PDSVHipEntryFull>()
            .HasRequired<PDSVHipEntry>(s => s.PDSVHipEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int>(s => s.PDSVHipEntryId3);












            // configures one-to-many relationship
            modelBuilder.Entity<BPVHipCombo>()
                .HasRequired<BPVHipStructure>(s => s.Str1).WithMany(g => g.BPVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<BPVHipCombo>()
                .HasOptional<BPVHipStructure>(s => s.Str2).WithMany(g => g.BPVs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<BPVHipCombo>()
                .HasOptional<BPVHipStructure>(s => s.Str3).WithMany(g => g.BPVs3).HasForeignKey<int?>(s => s.IdStr3);

            modelBuilder.Entity<BPVHipCombo>()
                .HasOptional<BPVHipStructure>(s => s.Str4).WithMany(g => g.BPVs4).HasForeignKey<int?>(s => s.IdStr4);

            modelBuilder.Entity<BPVHipCombo>()
                .HasOptional<BPVHipStructure>(s => s.Str5).WithMany(g => g.BPVs5).HasForeignKey<int?>(s => s.IdStr5);

            modelBuilder.Entity<BPVHipEntry>()
                .HasRequired<BPVHipStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);

            modelBuilder.Entity<BPVHipEntryFull>()
              .HasRequired<BPVHipWay>(s => s.BPVHipWay).WithMany(g => g.EntriesFull).HasForeignKey<int>(s => s.BPVHipWayID);

            modelBuilder.Entity<BPVHipEntryFull>()
            .HasRequired<BPVHipEntry>(s => s.BPVHipEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.BPVHipEntryId1);
            modelBuilder.Entity<BPVHipEntryFull>()
            .HasRequired<BPVHipEntry>(s => s.BPVHipEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int>(s => s.BPVHipEntryId2);

            modelBuilder.Entity<BPVHipEntryFull>()
            .HasRequired<BPVHipEntry>(s => s.BPVHipEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int>(s => s.BPVHipEntryId3);

            modelBuilder.Entity<BPVHipEntryFull>()
            .HasRequired<BPVHipEntry>(s => s.BPVHipEntry4).WithMany(g => g.EntriesFull4).HasForeignKey<int>(s => s.BPVHipEntryId4);

            modelBuilder.Entity<BPVHipEntryFull>()
            .HasRequired<BPVHipEntry>(s => s.BPVHipEntry5).WithMany(g => g.EntriesFull5).HasForeignKey<int>(s => s.BPVHipEntryId5);







            modelBuilder.Entity<SFSHipCombo>()
              .HasRequired<SFSHipStructure>(s => s.Str1).WithMany(g => g.SFSs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<SFSHipCombo>()
                .HasOptional<SFSHipStructure>(s => s.Str2).WithMany(g => g.SFSs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<SFSHipCombo>()
                .HasOptional<SFSHipStructure>(s => s.Str3).WithMany(g => g.SFSs3).HasForeignKey<int?>(s => s.IdStr3);

            modelBuilder.Entity<SFSHipCombo>()
                .HasOptional<SFSHipStructure>(s => s.Str4).WithMany(g => g.SFSs4).HasForeignKey<int?>(s => s.IdStr4);

            modelBuilder.Entity<SFSHipCombo>()
                .HasOptional<SFSHipStructure>(s => s.Str5).WithMany(g => g.SFSs5).HasForeignKey<int?>(s => s.IdStr5);
            modelBuilder.Entity<SFSHipCombo>()
               .HasOptional<SFSHipStructure>(s => s.Str6).WithMany(g => g.SFSs6).HasForeignKey<int?>(s => s.IdStr6);

            modelBuilder.Entity<SFSHipEntry>()
                .HasRequired<SFSHipStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);

            modelBuilder.Entity<SFSHipEntryFull>()
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.SFSHipEntryId1);
            modelBuilder.Entity<SFSHipEntryFull>()
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int>(s => s.SFSHipEntryId2);

            modelBuilder.Entity<SFSHipEntryFull>()
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int>(s => s.SFSHipEntryId3);

            modelBuilder.Entity<SFSHipEntryFull>()
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry4).WithMany(g => g.EntriesFull4).HasForeignKey<int>(s => s.SFSHipEntryId4);

            modelBuilder.Entity<SFSHipEntryFull>()
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry5).WithMany(g => g.EntriesFull5).HasForeignKey<int>(s => s.SFSHipEntryId5);

            modelBuilder.Entity<SFSHipEntryFull>()
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry6).WithMany(g => g.EntriesFull6).HasForeignKey<int>(s => s.SFSHipEntryId6);



        }
    }
}

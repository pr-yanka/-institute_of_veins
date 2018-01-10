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
        public MySqlContext() : base("server=localhost;user=root;database=med_db;password=22222;") {
            
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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

        }
    }
}

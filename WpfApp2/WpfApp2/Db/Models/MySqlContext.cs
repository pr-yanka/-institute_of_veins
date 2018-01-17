﻿using System;
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
        public MySqlContext() : base("server=localhost;user=root;database=med_db;password=22222;")
        {

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

        }
    }
}

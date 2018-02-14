using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.GV;
using WpfApp2.Db.Models.PPV;
using WpfApp2.Db.Models.SPS;
using WpfApp2.Messaging;

namespace WpfApp2.Db.Models
{
    public class MySqlContext : DbContext
    {



        public DbSet<ComplanesObs> ComplanesObs { get; set; }
        public DbSet<RecomendationObs> RecomendationObs { get; set; }

        public DbSet<BPVHipEntryFull> BPVHipsFull { get; set; }
        public DbSet<PDSVHipEntryFull> PDSVFull { get; set; }
        public DbSet<SFSHipEntryFull> SFSFull { get; set; }
        public DbSet<Perforate_hipEntryFull> Perforate_hipFull { get; set; }
        public DbSet<BPV_TibiaEntryFull> BPV_TibiaFull { get; set; }
        public DbSet<SPSHipEntryFull> SPSHipFull { get; set; }
        public DbSet<Perforate_shinEntryFull> Perforate_shinFull { get; set; }
        public DbSet<MPVEntryFull> MPVFull { get; set; }
        public DbSet<TEMPVEntryFull> TEMPVFull { get; set; }
        public DbSet<PPVEntryFull> PPVFull { get; set; }
        public DbSet<GVEntryFull> GVFull { get; set; }
        public DbSet<ZDSVEntryFull> ZDSVFull { get; set; }


        public DbSet<ExaminationLeg> ExaminationLeg { get; set; }
        public DbSet<doc_templates> doc_template { get; set; }

        public DbSet<GVStructure> GV { get; set; }
        public DbSet<GVCombo> GVCombos { get; set; }
        public DbSet<GVEntry> GVEntries { get; set; }


        public DbSet<PPVStructure> PPV { get; set; }
        public DbSet<PPVCombo> PPVCombos { get; set; }
        public DbSet<PPVEntry> PPVEntries { get; set; }

        public DbSet<Letters> Letters { get; set; }

        public DbSet<TEMPVWay> TEMPVWay { get; set; }
        public DbSet<MPVWay> MPVWay { get; set; }

        public DbSet<MPVStructure> MPV { get; set; }
        public DbSet<MPVCombo> MPVCombos { get; set; }
        public DbSet<MPVEntry> MPVEntries { get; set; }


        public DbSet<TEMPVStructure> TEMPV { get; set; }
        public DbSet<TEMPVCombo> TEMPVCombos { get; set; }
        public DbSet<TEMPVEntry> TEMPVEntries { get; set; }

        public DbSet<Perforate_shinStructure> Perforate_shin { get; set; }
        public DbSet<Perforate_shinCombo> Perforate_shinCombos { get; set; }
        public DbSet<Perforate_shinEntry> Perforate_shinEntries { get; set; }


        public DbSet<SPSHipStructure> SPS { get; set; }
        public DbSet<SPSHipCombo> SPSHipCombo { get; set; }
        public DbSet<SPSHipEntry> SPSHipEntry { get; set; }



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
        public DbSet<ChangesInDBType> ChangesInDBType { get; set; }
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

        public DbSet<ChangeHistory> ChangeHistory { get; set; }

        public DbSet<ZDSVStructure> ZDSV { get; set; }
        public DbSet<ZDSVCombo> ZDSVCombos { get; set; }
        public DbSet<ZDSVEntry> ZDSVEntries { get; set; }

        object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            try
            {
                var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
                return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
            }
            catch
            {
                return "new_id";
            }
        }

        int CurrAccId;

        private void SetCurrentACCIDForContext(object sender, object data)
        {
            CurrAccId = (int)data;
        }
        private string GetEntytyType(DbEntityEntry ent)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)this).ObjectContext;
            Type entityType = ent.Entity.GetType();

            if (entityType.BaseType != null && entityType.Namespace == "System.Data.Entity.DynamicProxies")
                entityType = entityType.BaseType;

            string entityTypeName = entityType.Name;

            EntityContainer container =
                objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace);
            string entitySetName = (from meta in container.BaseEntitySets
                                    where meta.ElementType.Name == entityTypeName
                                    select meta.Name).First();
            return entitySetName;
        }
        public string GetTableName(Type type, DbContext context)
        {
            var metadata = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;

            // Get the part of the model that contains info about the actual CLR types
            var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));

            // Get the entity type from the model that maps to the CLR type

            var entityType = metadata
                .GetItems<EntityType>(DataSpace.OSpace)
                .Single(e => objectItemCollection.GetClrType(e) == type);

            // Get the entity set that uses this entity type

            var entitySet = metadata
                .GetItems<EntityContainer>(DataSpace.CSpace)
                .Single()
                .EntitySets
                .Single(s => s.ElementType.Name == entityType.Name);

            // Find the mapping between conceptual and storage model for this entity set
            var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
                    .Single()
                    .EntitySetMappings
                    .Single(s => s.EntitySet == entitySet);

            // Find the storage entity set (table) that the entity is mapped
            var table = mapping
                .EntityTypeMappings.Single()
                .Fragments.Single()
                .StoreEntitySet;

            //            table.MetadataProperties[0].Name

            // Return the table name from the storage entity set
            return (string)table.MetadataProperties["Table"].Value ?? table.Name;

        }

        public string GetColumnName(Type type, string propertyName, DbContext context)
        {
            var metadata = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;

            // Get the part of the model that contains info about the actual CLR types
            var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));

            // Get the entity type from the model that maps to the CLR type
            var entityType = metadata
                    .GetItems<EntityType>(DataSpace.OSpace)
                          .Single(e => objectItemCollection.GetClrType(e) == type);

            // Get the entity set that uses this entity type
            var entitySet = metadata
                .GetItems<EntityContainer>(DataSpace.CSpace)
                      .Single()
                      .EntitySets
                      .Single(s => s.ElementType.Name == entityType.Name);

            // Find the mapping between conceptual and storage model for this entity set
            var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
                          .Single()
                          .EntitySetMappings
                          .Single(s => s.EntitySet == entitySet);

            // Find the storage entity set (table) that the entity is mapped
            // var tableEntitySet = mapping
            //.EntityTypeMappings.Single()
            //.Fragments.Single()
            //.StoreEntitySet;

            // Return the table name from the storage entity set
            // var tableName = tableEntitySet.MetadataProperties["Table"].Value ?? tableEntitySet.Name;

            // Find the storage property (column) that the property is mapped
            var columnName = mapping
                .EntityTypeMappings.Single()
                .Fragments.Single()
                .PropertyMappings
                .OfType<ScalarPropertyMapping>()
                      .Single(m => m.Property.Name == propertyName)
                .Column
                .Name;

            return columnName;
        }


        public override int SaveChanges()
        {
            List<ChangeHistory> logsList = new List<Models.ChangeHistory>();
            //List<DbEntityEntry> modifiedChanges = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();
            List<DbEntityEntry> modifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();

            List<DbEntityEntry> addedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Added).ToList();

            List<DbEntityEntry> deletedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Deleted).ToList();




            ChangeHistory logh = new Models.ChangeHistory();

            DateTime now = DateTime.UtcNow;

            foreach (var change in deletedEntities)
            {
                var tableName = GetTableName(ObjectContext.GetObjectType(change.Entity.GetType()), this);
                var entityName = GetEntytyType(change);
                if (entityName != "ChangeHistory")
                {
                    //var primaryKey = GetPrimaryKeyValue(change);

                    foreach (var prop in change.OriginalValues.PropertyNames)
                    {
                        if (change.OriginalValues[prop] != null)
                        {

                            var primaryKey = GetPrimaryKeyValue(change);
                            if (prop != "Id")
                            {
                                if (entityName == "Analize" && prop == "ImageByte")
                                {

                                    var originalValueBlob = (byte[])change.OriginalValues[prop];
                                    //var currentValueBlob = (byte[])change.CurrentValues[prop];





                                    logh = new Models.ChangeHistory()
                                    {

                                        TblName = tableName,
                                        AccID = CurrAccId,

                                        RowId = primaryKey.ToString(),

                                        TblCollumnName = GetColumnName(ObjectContext.GetObjectType(change.Entity.GetType()), prop, this),
                                        BlobNew = null,
                                        BlobOld = originalValueBlob,
                                        OldValue = string.Empty,
                                        NewValue = string.Empty,
                                        DataChanged = now,
                                        ChangeType = 3

                                    };


                                    logsList.Add(logh);

                                }
                                else
                                {


                                    var originalValue = change.OriginalValues[prop].ToString();
                                    //var currentValue = change.CurrentValues[prop].ToString();


                                    logh = new Models.ChangeHistory()
                                    {
                                        TblName = tableName,
                                        AccID = CurrAccId,
                                        RowId = primaryKey.ToString(),
                                        TblCollumnName = GetColumnName(ObjectContext.GetObjectType(change.Entity.GetType()), prop, this),
                                        OldValue = originalValue,
                                        BlobNew = null,
                                        BlobOld = null,
                                        NewValue = string.Empty,
                                        DataChanged = now,
                                        ChangeType = 3

                                    };

                                    logsList.Add(logh);

                                }
                            }
                        }
                    }
                }
            }



            foreach (var change in addedEntities)
            {

                var entityName = GetEntytyType(change);
                var tableName = GetTableName(ObjectContext.GetObjectType(change.Entity.GetType()), this);
                if (entityName != "ChangeHistory")
                {
                    //var primaryKey = GetPrimaryKeyValue(change);

                    foreach (var prop in change.CurrentValues.PropertyNames)
                    {
                        if (change.CurrentValues[prop] != null)
                        {

                            var primaryKey = GetPrimaryKeyValue(change);
                            if (prop != "Id")
                            {
                                if (entityName == "Analize" && prop == "ImageByte")
                                {

                                    //   var originalValueBlob = (byte[])change.OriginalValues[prop];
                                    var currentValueBlob = (byte[])change.CurrentValues[prop];





                                    logh = new Models.ChangeHistory()
                                    {

                                        TblName = tableName,
                                        AccID = CurrAccId,

                                        RowId = primaryKey.ToString(),

                                        TblCollumnName = GetColumnName(ObjectContext.GetObjectType(change.Entity.GetType()), prop, this),
                                        BlobNew = currentValueBlob,
                                        BlobOld = null,
                                        OldValue = string.Empty,
                                        NewValue = string.Empty,
                                        DataChanged = now,
                                        ChangeType = 2

                                    };


                                    logsList.Add(logh);

                                }
                                else
                                {


                                    // var originalValue = change.OriginalValues[prop].ToString();
                                    var currentValue = change.CurrentValues[prop].ToString();


                                    logh = new Models.ChangeHistory()
                                    {
                                        TblName = tableName,
                                        AccID = CurrAccId,
                                        RowId = primaryKey.ToString(),
                                        TblCollumnName = GetColumnName(ObjectContext.GetObjectType(change.Entity.GetType()), prop, this),
                                        OldValue = string.Empty,
                                        BlobNew = null,
                                        BlobOld = null,
                                        NewValue = currentValue,
                                        DataChanged = now,
                                        ChangeType = 2

                                    };

                                    logsList.Add(logh);

                                }
                            }
                        }
                    }
                }
            }


            foreach (var change in modifiedEntities)
            {
                var tableName = GetTableName(ObjectContext.GetObjectType(change.Entity.GetType()), this);
                // var entityName = GetEntytyType(change);

                string entityName = GetEntytyType(change);
                if (entityName != "ChangeHistory")
                {

                    var primaryKey = GetPrimaryKeyValue(change);

                    foreach (var prop in change.OriginalValues.PropertyNames)
                    {
                    
                        if (change.CurrentValues[prop] != null)
                        {
                            if (entityName == "Analize" && prop == "ImageByte")
                            {

                                var originalValueBlob = (byte[])change.OriginalValues[prop];
                                var currentValueBlob = (byte[])change.CurrentValues[prop];

                                if (originalValueBlob != currentValueBlob)
                                {

                                    logh = new Models.ChangeHistory()
                                    {
                                        TblName = tableName,
                                        AccID = CurrAccId,
                                        RowId = primaryKey.ToString(),
                                        TblCollumnName = GetColumnName(ObjectContext.GetObjectType(change.Entity.GetType()), prop, this),
                                        BlobNew = currentValueBlob,
                                        BlobOld = originalValueBlob,
                                        OldValue = string.Empty,
                                        NewValue = string.Empty,
                                        DataChanged = now,
                                        ChangeType = 1

                                    };


                                    logsList.Add(logh);
                                }
                            }
                            else
                            {
                                string originalValue = "";
                                if (change.OriginalValues[prop] != null)
                                {
                                    originalValue = change.OriginalValues[prop].ToString();
                                }
                                string currentValue = change.CurrentValues[prop].ToString();

                                if (originalValue != currentValue)
                                {


                                    logh = new Models.ChangeHistory()
                                    {
                                        TblName = tableName,
                                        AccID = CurrAccId,
                                        RowId = primaryKey.ToString(),
                                        TblCollumnName = GetColumnName(ObjectContext.GetObjectType(change.Entity.GetType()), prop, this),
                                        OldValue = originalValue,
                                        BlobNew = null,
                                        BlobOld = null,
                                        NewValue = currentValue,
                                        DataChanged = now,
                                        ChangeType = 1

                                    };

                                    logsList.Add(logh);
                                }
                            }
                        }
                    }
                }
            }
            //Saved

            if (addedEntities.Count > 0)
            {
                base.SaveChanges();


                foreach (var change in addedEntities)
                {
                    var tableName = GetTableName(ObjectContext.GetObjectType(change.Entity.GetType()), this);
                    var entityName = GetEntytyType(change);
                    if (entityName != "ChangeHistory")
                    {
                        //var primaryKey = GetPrimaryKeyValue(change);

                        foreach (var prop in change.CurrentValues.PropertyNames)
                        {
                            if (change.CurrentValues[prop] != null)
                            {

                                var primaryKey = GetPrimaryKeyValue(change);
                                if (entityName == "Analize" && prop == "ImageByte")
                                {

                                    var currentValueBlob = (byte[])change.CurrentValues[prop];
                                    foreach (var x in logsList)
                                    {
                                        if (x.TblName == tableName && x.AccID == CurrAccId && x.TblCollumnName == GetColumnName(ObjectContext.GetObjectType(change.Entity.GetType()), prop, this) && x.ChangeType == 2 && x.BlobNew == currentValueBlob)
                                        {
                                            x.RowId = primaryKey.ToString();
                                        }
                                    }

                                }
                                else
                                {


                                    // var originalValue = change.OriginalValues[prop].ToString();
                                    var currentValue = change.CurrentValues[prop].ToString();
                                    foreach (var x in logsList)
                                    {
                                        if (x.TblName == tableName && x.AccID == CurrAccId && x.TblCollumnName == GetColumnName(ObjectContext.GetObjectType(change.Entity.GetType()), prop, this) && x.ChangeType == 2 && x.NewValue == currentValue)
                                        {

                                            x.RowId = primaryKey.ToString();
                                        }
                                    }

                                }
                            }
                        }
                    }
                }


                //Saved
                foreach (var change in modifiedEntities)
                {

                    var tableName = GetTableName(ObjectContext.GetObjectType(change.Entity.GetType()), this);
                    var entityName = GetEntytyType(change);
                    if (entityName.Contains("Operation"))
                    {
                        entityName = "Operation";

                    }
                    if (entityName != "ChangeHistory")
                    {

                        var primaryKey = GetPrimaryKeyValue(change);

                        foreach (var prop in change.OriginalValues.PropertyNames)
                        {
                            if (change.CurrentValues[prop] != null && change.OriginalValues[prop] != null)
                            {
                                if (entityName == "Analize" && prop == "ImageByte")
                                {
                                    var currentValueBlob = (byte[])change.CurrentValues[prop];
                                    foreach (var x in logsList)
                                    {
                                        if (x.TblName == tableName && x.AccID == CurrAccId && x.TblCollumnName == GetColumnName(ObjectContext.GetObjectType(change.Entity.GetType()), prop, this) && x.ChangeType == 1 && x.RowId == primaryKey.ToString())
                                        {
                                            x.BlobNew = currentValueBlob;
                                        }
                                    }

                                }
                                else
                                {
                                    var currentValue = change.CurrentValues[prop].ToString();
                                    foreach (var x in logsList)
                                    {
                                        if (x.TblName == tableName && x.AccID == CurrAccId && x.TblCollumnName == GetColumnName(ObjectContext.GetObjectType(change.Entity.GetType()), prop, this) && x.ChangeType == 1 && x.RowId == primaryKey.ToString())
                                        {
                                            x.NewValue = currentValue;
                                        }
                                    }

                                    //  logsList.Add(logh);
                                }
                            }
                        }
                    }

                }
            }

            if (logsList.Count > 0)
                MessageBus.Default.Call("SaveLogs", null, logsList);







            return base.SaveChanges();


        }


        public MySqlContext() : base("server=localhost;user=root;database=med_db;password=22222;")
        {
            CurrAccId = 0;
            MessageBus.Default.Subscribe("SetCurrentACCIDForContext", SetCurrentACCIDForContext);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GVCombo>()
               .HasRequired<GVStructure>(s => s.Str1).WithMany(g => g.GVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<GVCombo>()
                .HasOptional<GVStructure>(s => s.Str2).WithMany(g => g.GVs2).HasForeignKey<int?>(s => s.IdStr2);



            modelBuilder.Entity<GVEntry>()
                .HasRequired<GVStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);


            modelBuilder.Entity<GVEntryFull>()
            .HasRequired<GVEntry>(s => s.GVEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);
            modelBuilder.Entity<GVEntryFull>()
            .HasRequired<GVEntry>(s => s.GVEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);





            modelBuilder.Entity<PPVCombo>()
               .HasRequired<PPVStructure>(s => s.Str1).WithMany(g => g.PPVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<PPVCombo>()
                .HasOptional<PPVStructure>(s => s.Str2).WithMany(g => g.PPVs2).HasForeignKey<int?>(s => s.IdStr2);



            modelBuilder.Entity<PPVEntry>()
                .HasRequired<PPVStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);


            modelBuilder.Entity<PPVEntryFull>()
            .HasRequired<PPVEntry>(s => s.PPVEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);
            modelBuilder.Entity<PPVEntryFull>()
            .HasRequired<PPVEntry>(s => s.PPVEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);













            modelBuilder.Entity<TEMPVCombo>()
                .HasRequired<TEMPVStructure>(s => s.Str1).WithMany(g => g.TEMPVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<TEMPVCombo>()
                .HasOptional<TEMPVStructure>(s => s.Str2).WithMany(g => g.TEMPVs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<TEMPVCombo>()
                .HasOptional<TEMPVStructure>(s => s.Str3).WithMany(g => g.TEMPVs3).HasForeignKey<int?>(s => s.IdStr3);


            modelBuilder.Entity<TEMPVEntry>()
                .HasRequired<TEMPVStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);

            modelBuilder.Entity<TEMPVEntryFull>()
              .HasRequired<TEMPVWay>(s => s.TEMPVWay).WithMany(g => g.EntriesFull).HasForeignKey<int?>(s => s.WayID);

            modelBuilder.Entity<TEMPVEntryFull>()
            .HasRequired<TEMPVEntry>(s => s.TEMPVEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);
            modelBuilder.Entity<TEMPVEntryFull>()
            .HasRequired<TEMPVEntry>(s => s.TEMPVEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);

            modelBuilder.Entity<TEMPVEntryFull>()
            .HasRequired<TEMPVEntry>(s => s.TEMPVEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int?>(s => s.EntryId3);










            modelBuilder.Entity<MPVCombo>()
                  .HasRequired<MPVStructure>(s => s.Str1).WithMany(g => g.MPVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<MPVCombo>()
                .HasOptional<MPVStructure>(s => s.Str2).WithMany(g => g.MPVs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<MPVCombo>()
                .HasOptional<MPVStructure>(s => s.Str3).WithMany(g => g.MPVs3).HasForeignKey<int?>(s => s.IdStr3);
            modelBuilder.Entity<MPVCombo>()
             .HasOptional<MPVStructure>(s => s.Str4).WithMany(g => g.MPVs4).HasForeignKey<int?>(s => s.IdStr4);


            modelBuilder.Entity<MPVEntry>()
                .HasRequired<MPVStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);

            modelBuilder.Entity<MPVEntryFull>()
              .HasRequired<MPVWay>(s => s.MPVWay).WithMany(g => g.EntriesFull).HasForeignKey<int?>(s => s.WayID);

            modelBuilder.Entity<MPVEntryFull>()
            .HasRequired<MPVEntry>(s => s.MPVEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);
            modelBuilder.Entity<MPVEntryFull>()
            .HasRequired<MPVEntry>(s => s.MPVEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);

            modelBuilder.Entity<MPVEntryFull>()
            .HasRequired<MPVEntry>(s => s.MPVEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int?>(s => s.EntryId3);
            modelBuilder.Entity<MPVEntryFull>()
          .HasRequired<MPVEntry>(s => s.MPVEntry4).WithMany(g => g.EntriesFull4).HasForeignKey<int?>(s => s.EntryId4);




            modelBuilder.Entity<SPSHipCombo>()
              .HasRequired<SPSHipStructure>(s => s.Str1).WithMany(g => g.SPSs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<SPSHipCombo>()
                .HasOptional<SPSHipStructure>(s => s.Str2).WithMany(g => g.SPSs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<SPSHipCombo>()
                .HasOptional<SPSHipStructure>(s => s.Str3).WithMany(g => g.SPSs3).HasForeignKey<int?>(s => s.IdStr3);


            modelBuilder.Entity<SPSHipEntry>()
                .HasRequired<SPSHipStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);


            modelBuilder.Entity<SPSHipEntryFull>()
            .HasRequired<SPSHipEntry>(s => s.SPSHipEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);

            modelBuilder.Entity<SPSHipEntryFull>()
            .HasRequired<SPSHipEntry>(s => s.SPSHipEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);

            modelBuilder.Entity<SPSHipEntryFull>()
            .HasRequired<SPSHipEntry>(s => s.SPSHipEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int?>(s => s.EntryId3);





            modelBuilder.Entity<Perforate_shinCombo>()
            .HasRequired<Perforate_shinStructure>(s => s.Str1).WithMany(g => g.BPVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<Perforate_shinCombo>()
                .HasOptional<Perforate_shinStructure>(s => s.Str2).WithMany(g => g.BPVs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<Perforate_shinCombo>()
                .HasOptional<Perforate_shinStructure>(s => s.Str3).WithMany(g => g.BPVs3).HasForeignKey<int?>(s => s.IdStr3);

            modelBuilder.Entity<Perforate_shinCombo>()
                .HasOptional<Perforate_shinStructure>(s => s.Str4).WithMany(g => g.BPVs4).HasForeignKey<int?>(s => s.IdStr4);

            modelBuilder.Entity<Perforate_shinCombo>()
                .HasOptional<Perforate_shinStructure>(s => s.Str5).WithMany(g => g.BPVs5).HasForeignKey<int?>(s => s.IdStr5);

            modelBuilder.Entity<Perforate_shinEntry>()
                .HasRequired<Perforate_shinStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);


            modelBuilder.Entity<Perforate_shinEntryFull>()
            .HasRequired<Perforate_shinEntry>(s => s.Perforate_shinEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);
            modelBuilder.Entity<Perforate_shinEntryFull>()
            .HasRequired<Perforate_shinEntry>(s => s.Perforate_shinEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);

            modelBuilder.Entity<Perforate_shinEntryFull>()
            .HasRequired<Perforate_shinEntry>(s => s.Perforate_shinEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int?>(s => s.EntryId3);

            modelBuilder.Entity<Perforate_shinEntryFull>()
            .HasRequired<Perforate_shinEntry>(s => s.Perforate_shinEntry4).WithMany(g => g.EntriesFull4).HasForeignKey<int?>(s => s.EntryId4);

            modelBuilder.Entity<Perforate_shinEntryFull>()
            .HasRequired<Perforate_shinEntry>(s => s.Perforate_shinEntry5).WithMany(g => g.EntriesFull5).HasForeignKey<int?>(s => s.EntryId5);









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
            .HasRequired<Perforate_hipEntry>(s => s.Perforate_hipEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);
            modelBuilder.Entity<Perforate_hipEntryFull>()
            .HasRequired<Perforate_hipEntry>(s => s.Perforate_hipEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);

            modelBuilder.Entity<Perforate_hipEntryFull>()
            .HasRequired<Perforate_hipEntry>(s => s.Perforate_hipEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int?>(s => s.EntryId3);

            modelBuilder.Entity<Perforate_hipEntryFull>()
            .HasRequired<Perforate_hipEntry>(s => s.Perforate_hipEntry4).WithMany(g => g.EntriesFull4).HasForeignKey<int?>(s => s.EntryId4);

            modelBuilder.Entity<Perforate_hipEntryFull>()
            .HasRequired<Perforate_hipEntry>(s => s.Perforate_hipEntry5).WithMany(g => g.EntriesFull5).HasForeignKey<int?>(s => s.EntryId5);










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
            .HasRequired<BPV_TibiaEntry>(s => s.BPV_TibiaEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);

            modelBuilder.Entity<BPV_TibiaEntryFull>()
            .HasRequired<BPV_TibiaEntry>(s => s.BPV_TibiaEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);

            modelBuilder.Entity<BPV_TibiaEntryFull>()
            .HasRequired<BPV_TibiaEntry>(s => s.BPV_TibiaEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int?>(s => s.EntryId3);

            modelBuilder.Entity<BPV_TibiaEntryFull>()
            .HasRequired<BPV_TibiaEntry>(s => s.BPV_TibiaEntry4).WithMany(g => g.EntriesFull4).HasForeignKey<int?>(s => s.EntryId4);





            modelBuilder.Entity<ZDSVCombo>()
              .HasRequired<ZDSVStructure>(s => s.Str1).WithMany(g => g.ZDSVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<ZDSVCombo>()
                .HasOptional<ZDSVStructure>(s => s.Str2).WithMany(g => g.ZDSVs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<ZDSVCombo>()
                .HasOptional<ZDSVStructure>(s => s.Str3).WithMany(g => g.ZDSVs3).HasForeignKey<int?>(s => s.IdStr3);


            modelBuilder.Entity<ZDSVEntry>()
                .HasRequired<ZDSVStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);


            modelBuilder.Entity<ZDSVEntryFull>()
            .HasRequired<ZDSVEntry>(s => s.ZDSVEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);
            modelBuilder.Entity<ZDSVEntryFull>()
            .HasRequired<ZDSVEntry>(s => s.ZDSVEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);

            modelBuilder.Entity<ZDSVEntryFull>()
            .HasRequired<ZDSVEntry>(s => s.ZDSVEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int?>(s => s.EntryId3);










            modelBuilder.Entity<PDSVHipCombo>()
                .HasRequired<PDSVHipStructure>(s => s.Str1).WithMany(g => g.PDSVs1).HasForeignKey<int>(s => s.IdStr1);

            modelBuilder.Entity<PDSVHipCombo>()
                .HasOptional<PDSVHipStructure>(s => s.Str2).WithMany(g => g.PDSVs2).HasForeignKey<int?>(s => s.IdStr2);

            modelBuilder.Entity<PDSVHipCombo>()
                .HasOptional<PDSVHipStructure>(s => s.Str3).WithMany(g => g.PDSVs3).HasForeignKey<int?>(s => s.IdStr3);


            modelBuilder.Entity<PDSVHipEntry>()
                .HasRequired<PDSVHipStructure>(s => s.Structure).WithMany(g => g.Entries).HasForeignKey<int>(s => s.StructureID);

            modelBuilder.Entity<PDSVHipEntryFull>()
              .HasRequired<PDSVHipWay>(s => s.PDSVHipWay).WithMany(g => g.EntriesFull).HasForeignKey<int?>(s => s.WayID);

            modelBuilder.Entity<PDSVHipEntryFull>()
            .HasRequired<PDSVHipEntry>(s => s.PDSVHipEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);
            modelBuilder.Entity<PDSVHipEntryFull>()
            .HasRequired<PDSVHipEntry>(s => s.PDSVHipEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);

            modelBuilder.Entity<PDSVHipEntryFull>()
            .HasRequired<PDSVHipEntry>(s => s.PDSVHipEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int?>(s => s.EntryId3);












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
              .HasRequired<BPVHipWay>(s => s.BPVHipWay).WithMany(g => g.EntriesFull).HasForeignKey<int?>(s => s.WayID);

            modelBuilder.Entity<BPVHipEntryFull>()
            .HasRequired<BPVHipEntry>(s => s.BPVHipEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);
            modelBuilder.Entity<BPVHipEntryFull>()
            .HasRequired<BPVHipEntry>(s => s.BPVHipEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);

            modelBuilder.Entity<BPVHipEntryFull>()
            .HasRequired<BPVHipEntry>(s => s.BPVHipEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int?>(s => s.EntryId3);

            modelBuilder.Entity<BPVHipEntryFull>()
            .HasRequired<BPVHipEntry>(s => s.BPVHipEntry4).WithMany(g => g.EntriesFull4).HasForeignKey<int?>(s => s.EntryId4);

            modelBuilder.Entity<BPVHipEntryFull>()
            .HasRequired<BPVHipEntry>(s => s.BPVHipEntry5).WithMany(g => g.EntriesFull5).HasForeignKey<int?>(s => s.EntryId5);







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
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry1).WithMany(g => g.EntriesFull1).HasForeignKey<int>(s => s.EntryId1);
            modelBuilder.Entity<SFSHipEntryFull>()
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry2).WithMany(g => g.EntriesFull2).HasForeignKey<int?>(s => s.EntryId2);

            modelBuilder.Entity<SFSHipEntryFull>()
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry3).WithMany(g => g.EntriesFull3).HasForeignKey<int?>(s => s.EntryId3);

            modelBuilder.Entity<SFSHipEntryFull>()
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry4).WithMany(g => g.EntriesFull4).HasForeignKey<int?>(s => s.EntryId4);

            modelBuilder.Entity<SFSHipEntryFull>()
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry5).WithMany(g => g.EntriesFull5).HasForeignKey<int?>(s => s.EntryId5);

            modelBuilder.Entity<SFSHipEntryFull>()
            .HasRequired<SFSHipEntry>(s => s.SFSHipEntry6).WithMany(g => g.EntriesFull6).HasForeignKey<int?>(s => s.EntryId6);



        }

        public class ChangeLog
        {
            public int Id { get; set; }
            public string EntityName { get; set; }
            public string PropertyName { get; set; }
            public string PrimaryKeyValue { get; set; }
            public string OldValue { get; set; }
            public string NewValue { get; set; }
            public DateTime DateChanged { get; set; }
        }
    }
}

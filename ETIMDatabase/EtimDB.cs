namespace ETIMDatabase
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ETIMDatabase.Entities;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class EtimDB : DbContext
    {
        public EtimDB() : base("name=EtimDB")
        {
            Database.SetInitializer(new ETIM6XmlInitializer(@"C:\Users\Alexander Derck\Downloads\ETIM standard\etim 6 - international - e - ixf - endenl\Etim6.xml"));
        }

        public virtual DbSet<EtimClass> Classes { get; set; }
        public virtual DbSet<EtimFeature> Features { get; set; }
        public virtual DbSet<EtimGroup> Groups { get; set; }
        public virtual DbSet<EtimUnit> Units { get; set; }
        public virtual DbSet<EtimValue> Values { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<EtimGroup>()
                .HasMany(m => m.Translations)
                .WithRequired(m => m.Group)
                .HasForeignKey(m => m.GroupCode);
            modelBuilder.Entity<EtimGroup>()
                .HasMany(m => m.Classes)
                .WithRequired(m => m.Group)
                .HasForeignKey(m => m.GroupCode);

            modelBuilder.Entity<EtimClass>()
                .HasMany(m => m.Translations)
                .WithRequired(m => m.Class)
                .HasForeignKey(m => m.ClassCode);

            modelBuilder.Entity<EtimClassFeature>()
                .HasRequired(m => m.Class)
                .WithMany(m => m.ClassFeatures)
                .HasForeignKey(m => m.ClassCode);
            modelBuilder.Entity<EtimClassFeature>()
                .HasRequired(m => m.Feature)
                .WithMany()
                .HasForeignKey(m => m.FeatureCode);
            modelBuilder.Entity<EtimClassFeature>()
                .HasMany(m => m.FeatureValues)
                .WithRequired(m => m.ClassFeature)
                .HasForeignKey(m => m.ClassFeatureID);
            modelBuilder.Entity<EtimClassFeature>()
                .HasOptional(m => m.Unit)
                .WithMany()
                .HasForeignKey(m => m.UnitCode);

            modelBuilder.Entity<EtimClassFeatureValue>()
                .HasRequired(m => m.Value)
                .WithMany()
                .HasForeignKey(m => m.ValueCode);

            modelBuilder.Entity<EtimValue>()
                .HasMany(m => m.Translations)
                .WithRequired(m => m.Value)
                .HasForeignKey(m => m.ValueCode);

            modelBuilder.Entity<EtimUnit>()
                .HasMany(m => m.Translations)
                .WithRequired(m => m.Unit)
                .HasForeignKey(m => m.UnitCode);

            base.OnModelCreating(modelBuilder);
        }
    }
}
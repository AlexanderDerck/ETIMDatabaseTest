namespace ETIMDatabase
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ETIMDatabase.Entities;

    public class EtimDB : DbContext
    {
        public EtimDB() : base("name=EtimDB")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EtimDB>());
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Value> Values { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(m => m.Translations)
                .WithRequired(m => m.Group)
                .HasForeignKey(m => m.GroupCode);
            modelBuilder.Entity<Group>()
                .HasMany(m => m.Classes)
                .WithRequired(m => m.Group)
                .HasForeignKey(m => m.GroupCode);

            modelBuilder.Entity<Class>()
                .HasMany(m => m.Translations)
                .WithRequired(m => m.Class)
                .HasForeignKey(m => m.ClassCode);

            modelBuilder.Entity<ClassFeature>()
                .HasRequired(m => m.Class)
                .WithMany()
                .HasForeignKey(m => m.ClassCode);
            modelBuilder.Entity<ClassFeature>()
                .HasRequired(m => m.Feature)
                .WithMany()
                .HasForeignKey(m => m.FeatureCode);
            modelBuilder.Entity<ClassFeature>()
                .HasMany(m => m.FeatureValues)
                .WithRequired(m => m.ClassFeature)
                .HasForeignKey(m => m.ClassFeatureID);

            modelBuilder.Entity<ClassFeatureValue>()
                .HasRequired(m => m.Value)
                .WithMany()
                .HasForeignKey(m => m.ValueCode);

            modelBuilder.Entity<Value>()
                .HasMany(m => m.Translations)
                .WithRequired(m => m.Value)
                .HasForeignKey(m => m.ValueCode);

            modelBuilder.Entity<Unit>()
                .HasMany(m => m.Translations)
                .WithRequired(m => m.Unit)
                .HasForeignKey(m => m.UnitCode);

            base.OnModelCreating(modelBuilder);
        }
    }
}
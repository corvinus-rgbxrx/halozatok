using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HajosTeszt.Models
{
    public partial class RGBXRXContext : DbContext
    {
        public RGBXRXContext()
        {
        }

        public RGBXRXContext(DbContextOptions<RGBXRXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SzallodaMunkavallalo> SzallodaMunkavallalos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=corvinusdataba.database.windows.net;Initial Catalog=RGBXRX;User ID=greta00178;Password=20Valami");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hungarian_CI_AS");

            modelBuilder.Entity<SzallodaMunkavallalo>(entity =>
            {
                entity.HasKey(e => e.MunkasId);

                entity.ToTable("Szalloda_Munkavallalo");

                entity.Property(e => e.MunkasId)
                    .ValueGeneratedNever()
                    .HasColumnName("MunkasID");

                entity.Property(e => e.Foglalkozas)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Munkavallalonev)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

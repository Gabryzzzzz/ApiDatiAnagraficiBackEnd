using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiDatiAnagrafici.Entities.Database
{
    public partial class dati_anagraficiContext : DbContext
    {
        public dati_anagraficiContext()
        {
        }

        public dati_anagraficiContext(DbContextOptions<dati_anagraficiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DatiAnagrafici> DatiAnagrafici { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=dati_anagrafici;user=user;password=User");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatiAnagrafici>(entity =>
            {
                entity.ToTable("dati_anagrafici");

                entity.Property(e => e.CodiceFiscale)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cognome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataDiNascita).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NoteApplication.Models
{
    public partial class NotesDBContext : DbContext
    {
        public NotesDBContext()
        {
        }

        public NotesDBContext(DbContextOptions<NotesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notes> Notes { get; set; }

        public static string GetConnectionString()
        {
            return Startup.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-SS45S0U;Database=NotesDB;Trusted_Connection=True;");
                var con = GetConnectionString();
                optionsBuilder.UseSqlServer(con);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.LastUpdated).HasColumnType("date");

                entity.Property(e => e.Note).HasColumnType("ntext");

                entity.Property(e => e.Title).HasColumnType("ntext");
            });
        }
    }
}

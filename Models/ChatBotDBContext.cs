using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoApi.Models
{
    public partial class ChatBotDBContext : DbContext
    {
        //public ChatBotDBContext()
        //{
        //}

        public ChatBotDBContext(DbContextOptions<ChatBotDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HackRegistration> HackRegistration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=24088JNBPBB240L\\SQLEXPRESS;Initial Catalog=ChatBotDB;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HackRegistration>(entity =>
            {
                entity.Property(e => e.AreaCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

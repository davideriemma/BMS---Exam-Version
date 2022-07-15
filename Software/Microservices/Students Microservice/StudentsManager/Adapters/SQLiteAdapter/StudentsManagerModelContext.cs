using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentManager.Adapters.SQLiteAdapter
{
    public partial class StudentsManagerModelContext : DbContext
    {
        public StudentsManagerModelContext()
        {
        }

        public StudentsManagerModelContext(DbContextOptions<StudentsManagerModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Email> Emails { get; set; } = null!;
        public virtual DbSet<Parent> Parents { get; set; } = null!;
        public virtual DbSet<ParentAddress> ParentAddresses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentAddress> StudentAddresses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=..\\..\\..\\StudentsManagerModel.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.InternalAddressId);

                entity.Property(e => e.InternalAddressId).HasColumnName("InternalAddressID");

                entity.Property(e => e.Provincia).HasColumnType("TEXT(2)");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Email1)
                    .HasColumnType("TEXT(255)")
                    .HasColumnName("email");

                entity.Property(e => e.StudentCf)
                    .HasColumnType("TEXT(16)")
                    .HasColumnName("StudentCF");

                entity.HasOne(d => d.StudentCfNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.StudentCf);
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasKey(e => e.Cf);

                entity.Property(e => e.Cf)
                    .HasColumnType("TEXT(16)")
                    .HasColumnName("CF");

                entity.Property(e => e.DateOfBirth).HasColumnType("TEXT(255)");

                entity.Property(e => e.Gender).HasColumnType("TEXT(1)");

                entity.Property(e => e.Name).HasColumnType("TEXT(255)");

                entity.Property(e => e.StudentId)
                    .HasColumnType("TEXT(16)")
                    .HasColumnName("StudentID");

                entity.Property(e => e.Surname).HasColumnType("TEXT(255)");

                entity.HasOne(d => d.CfNavigation)
                    .WithOne(p => p.Parent)
                    .HasForeignKey<Parent>(d => d.Cf)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ParentAddress>(entity =>
            {
                entity.HasKey(e => e.RelationId);

                entity.Property(e => e.RelationId)
                    .HasColumnType("integer")
                    .HasColumnName("RelationID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ParentId)
                    .HasColumnType("TEXT(16)")
                    .HasColumnName("ParentID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ParentAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.ParentAddresses)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Cf);

                entity.Property(e => e.Cf)
                    .HasColumnType("TEXT(16)")
                    .HasColumnName("CF");

                entity.Property(e => e.DateOfBirth).HasColumnType("TEXT(255)");

                entity.Property(e => e.Gender).HasColumnType("TEXT(1)");

                entity.Property(e => e.Name).HasColumnType("TEXT(255)");

                entity.Property(e => e.Surname).HasColumnType("TEXT(255)");
            });

            modelBuilder.Entity<StudentAddress>(entity =>
            {
                entity.HasKey(e => e.RelationId);

                entity.Property(e => e.RelationId).HasColumnName("RelationID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.StudentId)
                    .HasColumnType("TEXT(16)")
                    .HasColumnName("StudentID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.StudentAddresses)
                    .HasForeignKey(d => d.AddressId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentAddresses)
                    .HasForeignKey(d => d.StudentId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

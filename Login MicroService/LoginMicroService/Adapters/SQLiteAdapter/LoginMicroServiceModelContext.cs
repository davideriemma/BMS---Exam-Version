using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoginMicroService.Model
{
    public partial class LoginMicroServiceModelContext : DbContext
    {
        public LoginMicroServiceModelContext()
        {
        }

        public LoginMicroServiceModelContext(DbContextOptions<LoginMicroServiceModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Key> Keys { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Token> Tokens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=LoginMicroServiceModel.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Key>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Private).HasColumnName("private");

                entity.Property(e => e.Public).HasColumnName("public");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Login");

                entity.Property(e => e.Username).HasColumnName("username");

                entity.Property(e => e.Hashed).HasColumnName("hashed");

                entity.Property(e => e.Role).HasColumnName("role");
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Token");

                entity.Property(e => e.Username).HasColumnName("username");

                entity.Property(e => e.Token1).HasColumnName("Token");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.Token)
                    .HasForeignKey<Token>(d => d.Username);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RP.ExpenseTracker.DataAccess.Models
{
    public partial class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext()
        {
        }

        public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<ExpenseSubTypes> ExpenseSubTypes { get; set; }
        public virtual DbSet<ExpenseTypes> ExpenseTypes { get; set; }
        public virtual DbSet<PaymentModes> PaymentModes { get; set; }
        public virtual DbSet<UserAccounts> UserAccounts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ROHITP\\SQLEXPRESS;Initial Catalog=ExpenseTracker;Integrated Security=False;User ID=sa;Password=mosl_123;Connect Timeout=15;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.Property(e => e.AcknowledgmentNo).HasMaxLength(200);

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.DateOfExpenditure)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ExpenseSubType)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.ExpenseSubTypeId)
                    .HasConstraintName("FK__Expenses__Expens__286302EC");

                entity.HasOne(d => d.PaymentMode)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.PaymentModeId)
                    .HasConstraintName("FK__Expenses__Paymen__276EDEB3");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.UserAccountId)
                    .HasConstraintName("FK__Expenses__UserAc__267ABA7A");
            });

            modelBuilder.Entity<ExpenseSubTypes>(entity =>
            {
                entity.Property(e => e.ExpenseSubType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.ExpenseSubTypes)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK__ExpenseSu__Expen__21B6055D");
            });

            modelBuilder.Entity<ExpenseTypes>(entity =>
            {
                entity.Property(e => e.ExpenseType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PaymentModes>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<UserAccounts>(entity =>
            {
                entity.Property(e => e.AccountNo).HasMaxLength(100);

                entity.Property(e => e.AccountOrg).HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserAccou__UserI__1CF15040");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Passkey)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30);
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppOct19
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options)
    : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(e =>
            {
                e.ToTable("Accounts");

                e.HasKey(a => a.AccountNumber);

                e.Property(a => a.AccountNumber)
                    .ValueGeneratedOnAdd();

                e.Property(a => a.AccountName)
                    .HasMaxLength(50)
                    .IsRequired();

                e.Property(a => a.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(a => a.AccountType)
                    .IsRequired();
            });

            modelBuilder.Entity<Transaction>(e =>
            {
                e.ToTable("Transactions");

                e.HasKey(t => t.Id);
                e.Property(t => t.Id)
                    .ValueGeneratedOnAdd();

                e.Property(t => t.TransactionDate)
                    .IsRequired();

                e.Property(t => t.Amount)
                    .IsRequired();

                e.Property(t => t.TransactionType)
                    .IsRequired();

                e.HasOne(t => t.Account)
                    .WithMany()
                    .HasForeignKey(t => t.AccountNumber);
            });
        }
    }
}

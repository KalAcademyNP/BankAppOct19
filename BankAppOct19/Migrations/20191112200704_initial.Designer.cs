﻿// <auto-generated />
using System;
using BankAppOct19;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankAppOct19.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20191112200704_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankAppOct19.Account", b =>
                {
                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("AccountType");

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("AccountNumber");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankAppOct19.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountNumber");

                    b.Property<decimal>("Amount");

                    b.Property<decimal>("Balance");

                    b.Property<string>("Description");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<int>("TransactionType");

                    b.HasKey("Id");

                    b.HasIndex("AccountNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BankAppOct19.Transaction", b =>
                {
                    b.HasOne("BankAppOct19.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

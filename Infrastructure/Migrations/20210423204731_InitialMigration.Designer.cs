﻿// <auto-generated />
using System;
using MatthewKoo.BudgetTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatthewKoo.BudgetTracker.Infrastructure.Migrations
{
    [DbContext(typeof(BudgetTrackerDbContext))]
    [Migration("20210423204731_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MatthewKoo.BudgetTracker.ApplicationCore.Entities.Expenditure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .IsRequired()
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ExpDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Remarks")
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Expenditures");
                });

            modelBuilder.Entity("MatthewKoo.BudgetTracker.ApplicationCore.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .IsRequired()
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("IncomeDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Remarks")
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("MatthewKoo.BudgetTracker.ApplicationCore.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Fullname")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("JoinedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MatthewKoo.BudgetTracker.ApplicationCore.Entities.Expenditure", b =>
                {
                    b.HasOne("MatthewKoo.BudgetTracker.ApplicationCore.Entities.User", "User")
                        .WithMany("Expenditures")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MatthewKoo.BudgetTracker.ApplicationCore.Entities.Income", b =>
                {
                    b.HasOne("MatthewKoo.BudgetTracker.ApplicationCore.Entities.User", "User")
                        .WithMany("Incomes")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MatthewKoo.BudgetTracker.ApplicationCore.Entities.User", b =>
                {
                    b.Navigation("Expenditures");

                    b.Navigation("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}

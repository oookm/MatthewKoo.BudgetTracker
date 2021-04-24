using MatthewKoo.BudgetTracker.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.Infrastructure.Data
{
    public class BudgetTrackerDbContext : DbContext
    {
        public BudgetTrackerDbContext(DbContextOptions<BudgetTrackerDbContext> options) : base(options)
        {
        }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Income>().HasOne<User>(i => i.User).
                WithMany(u => u.Incomes).HasForeignKey(i => i.UserId);
            modelBuilder.Entity<Expenditure>().HasOne<User>(e => e.User).
                WithMany(u => u.Expenditures).HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Expenditure>(ConfigureExpenditure);
            modelBuilder.Entity<Income>(ConfigureIncome);
            modelBuilder.Entity<User>(ConfigureUser);
        }
        private void ConfigureExpenditure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.ToTable("Expenditures");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Amount).IsRequired();
            builder.Property(e => e.Amount).HasColumnType("money");
            builder.Property(e => e.Description).HasColumnType("varchar(100)");
            builder.Property(e => e.ExpDate).HasColumnType("datetime");
            builder.Property(e => e.Remarks).HasColumnType("varchar(500)");
        }
        private void ConfigureIncome(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Incomes");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Amount).IsRequired();
            builder.Property(i => i.Amount).HasColumnType("money");
            builder.Property(i => i.Description).HasColumnType("varchar(100)");
            builder.Property(i => i.IncomeDate).HasColumnType("datetime");
            builder.Property(i => i.Remarks).HasColumnType("varchar(500)");
        }
        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Email).HasColumnType("varchar(50)");
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Password).HasColumnType("varchar(10)");
            builder.Property(u => u.Fullname).HasColumnType("varchar(50)");
            builder.Property(u => u.JoinedOn).HasColumnType("datetime");
            builder.Property(u => u.JoinedOn).HasDefaultValueSql("getdate()");
        }
    }
}

using bART.Domain.Configurations;
using bART.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace bART.Domain
{
    public class bARTDBContext:DbContext
    {
        public bARTDBContext(DbContextOptions<bARTDBContext> options) : base(options) { }
        public DbSet<IncidentEntity> Incidents { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bARTSolutions;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new IncidentConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
        }
    }
}

using Assessment_MS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Assessment_MS.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _ConnectionString;

        public AppDbContext(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SurveyRecord>? SurveyRecords { get; set; }
        public string ConnectionString { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name).HasData(
                    new SurveyRecord("2", "Billy Nomates", "Billy.Nomates@notsure.com", true, 5, "3 the lane", "", "Peterborough", "Cambs", "PE01 8PE")
                    );
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString);
        }
    }
}

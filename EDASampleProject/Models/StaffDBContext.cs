using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EDASampleProject.Models
{
    public class StaffDBContext : DbContext
    {
        public StaffDBContext() : base("DataConnection")
        {
        }

        public DbSet<staff01office_info> staff01office_info { get; set; }
        public DbSet<staff02personal_info> staff02personal_info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<staff01office_info>()
                .HasMany(s => s.staff02personal_info)
                .WithRequired(g => g.staff01office_info)
                .HasForeignKey<int>(s => s.staff02uin01uin)
                .WillCascadeOnDelete(false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AngularJsWithMVC.Models
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext() : base("EmployeeConnectionString") { }

        public DbSet<Employee> EmployeeDB { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
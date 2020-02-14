using EFDAL.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace EFDAL.Context
{
    public class ProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3238117\SQLEXPRESS;Initial Catalog=ProDB;Persist Security Info=True;User ID=sa;Password=pass@word1");

           
        }
        public DbSet<Project> projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

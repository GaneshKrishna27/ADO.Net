using HandsOnEFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnEFCodeFirst.Context
{
    class StudentContext:DbContext
    {
        public DbSet<Student> student { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3238117\SQLEXPRESS;Initial Catalog=PracticeDB;Persist Security Info=True;User ID=sa;Password=pass@word1");
        }
    }
}

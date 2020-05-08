using Employee_Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_DataAccessLayer
{
    public class Employee_DBContext : DbContext
    {
        public Employee_DBContext() { }
        public Employee_DBContext(DbContextOptions<Employee_DBContext> options): base (options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        public virtual DbSet<EmployeeDetails> Employee { get; set; }
    }
}

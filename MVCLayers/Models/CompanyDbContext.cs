﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCLayers.ViewModels;

namespace MVCLayers.Models
{
    public class CompanyDbContext:IdentityDbContext<User>
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Emp_Proj> Emp_Projs { get; set; }
        public virtual DbSet<Dept_loc> Dept_Locs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CompanyLayers;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dependent>().HasKey("Emp_SSN", "Name");
            modelBuilder.Entity<Emp_Proj>().HasKey("Emp_SSN", "Proj_Id");
            modelBuilder.Entity<Dept_loc>().HasKey("Dept_id", "Locatoin");
            modelBuilder.Entity<Department>().HasOne(c => c.employee).WithOne(c => c.department);
            modelBuilder.Entity<Department>().HasMany(c => c.Employees).WithOne(c => c.manage);
            base.OnModelCreating(modelBuilder);


        }
        public DbSet<MVCLayers.ViewModels.RegistrationVM> RegistrationVM { get; set; } = default!;
        public DbSet<MVCLayers.ViewModels.LoginVM> LoginVM { get; set; } = default!;
    }
}

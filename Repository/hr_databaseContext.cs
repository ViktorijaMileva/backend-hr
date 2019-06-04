using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Hr_management_system.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Hr_management_system.Repository
{
    public partial class hr_databaseContext : IdentityDbContext
    {
        public hr_databaseContext()
        {
        }

        public hr_databaseContext(DbContextOptions<hr_databaseContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Leaves> Leaves { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAKI-PC\\SQLEXPRESS; Database=hr_database; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("departments");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DepartmentCity)
                    .HasColumnName("department_city")
                    .HasMaxLength(50);

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("department_name")
                    .HasMaxLength(50);

                entity.Property(e => e.DepartmentNumber).HasColumnName("department_number");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("manager_id")
                    .HasMaxLength(5);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasColumnName("zip_code");
            });

            modelBuilder.Entity<EmployeeInfo>(entity =>
            {
                entity.HasKey(e => e.Embg);

                entity.ToTable("employee_info");

                entity.Property(e => e.Embg)
                    .HasColumnName("embg")
                    .HasMaxLength(13)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.Embg);

                entity.ToTable("employees");

                entity.Property(e => e.Embg)
                    .HasColumnName("embg")
                    .HasMaxLength(13)
                    .ValueGeneratedNever();

                entity.Property(e => e.DateHired)
                    .HasColumnName("date_hired")
                    .HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.ToTable("jobs");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobName)
                    .HasColumnName("job_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Leaves>(entity =>
            {
                entity.HasKey(e => e.LeaveId);

                entity.ToTable("leaves");

                entity.Property(e => e.LeaveId).HasColumnName("leave_id");

                entity.Property(e => e.Embg)
                    .HasColumnName("embg")
                    .HasMaxLength(13);

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });
        }
    }
}

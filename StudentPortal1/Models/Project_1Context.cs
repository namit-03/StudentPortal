using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentPortal1.Models
{
    public partial class Project_1Context : DbContext
    {

        DbContextOptions _ob;
       
        Project_1Context(DbContextOptions ob)
        {
            _ob = ob;
        }

        public Project_1Context(DbContextOptions<Project_1Context> options)
            : base(options)
        {
        }

         public Project_1Context()
        {

        }

        public virtual DbSet<StudentAttendance> StudentAttendance { get; set; }
        public virtual DbSet<StudentLogin> StudentLogin { get; set; }
        public virtual DbSet<StudentMarks> StudentMarks { get; set; }
        public virtual DbSet<StudentRegister> StudentRegister { get; set; }
        public virtual DbSet<TeacherLogin> TeacherLogin { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentAttendance>(entity =>
            {
                entity.HasKey(e => e.Rollno)
                    .HasName("PK__Student___788BC9B833180B77");

                entity.ToTable("Student_Attendance");

                entity.Property(e => e.Rollno).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentLogin>(entity =>
            {
                entity.HasKey(e => e.Rollno);

                entity.ToTable("Student_Login");

                entity.Property(e => e.Rollno).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentMarks>(entity =>
            {
                entity.HasKey(e => e.Rollno);

                entity.ToTable("Student_Marks");

                entity.Property(e => e.Rollno).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentRegister>(entity =>
            {
                entity.HasKey(e => e.Rollno);

                entity.ToTable("Student_Register");

                entity.Property(e => e.Rollno).ValueGeneratedNever();

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
                    .IsRequired()
                    .HasColumnName("section")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TeacherLogin>(entity =>
            {
                entity.HasKey(e => e.TeacherId);

                entity.ToTable("Teacher_Login");

                entity.Property(e => e.TeacherId)
                    .HasColumnName("Teacher_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

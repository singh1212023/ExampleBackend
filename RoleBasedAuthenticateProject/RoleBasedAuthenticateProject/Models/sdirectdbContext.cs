using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RoleBasedAuthenticateProject.Models
{
    public partial class sdirectdbContext : DbContext
    {
        public sdirectdbContext()
        {
        }

        public sdirectdbContext(DbContextOptions<sdirectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MyLoginTable227> MyLoginTable227s { get; set; } = null!;
        public virtual DbSet<RoleMaster227> RoleMaster227s { get; set; } = null!;
        public virtual DbSet<SatyamMiddleWare> SatyamMiddleWares { get; set; } = null!;
        public virtual DbSet<SatyamStudent> SatyamStudents { get; set; } = null!;
        public virtual DbSet<SatyamTeacher> SatyamTeachers { get; set; } = null!;
        public virtual DbSet<UserRoleMapping227> UserRoleMapping227s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-U0U6071H\\SQLEXPRESS;Initial Catalog=sdirectdb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyLoginTable227>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__MyLoginT__1788CC4CCC733497");

                entity.ToTable("MyLoginTable227");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoleMaster227>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__RoleMast__8AFACE1A0214F9B3");

                entity.ToTable("RoleMaster227");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SatyamMiddleWare>(entity =>
            {
                entity.HasKey(e => e.MiddleWareId)
                    .HasName("PK__SatyamMi__E4ED4A5D7AD00C20");

                entity.ToTable("SatyamMiddleWare");

                entity.Property(e => e.MiddleWareIp)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MiddleWareIP");

                entity.Property(e => e.MiddleWareName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("middleWareName");
            });

            modelBuilder.Entity<SatyamStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__SatyamSt__32C52B994BB33FF4");

                entity.ToTable("SatyamStudent");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.StudentEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SatyamTeacher>(entity =>
            {
                entity.HasKey(e => e.TeacherId)
                    .HasName("PK__SatyamTe__EDF25964B4B5468A");

                entity.ToTable("SatyamTeacher");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.TeacherEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRoleMapping227>(entity =>
            {
                entity.HasKey(e => e.RoleMapId)
                    .HasName("PK__UserRole__5619E0A28EADB9D4");

                entity.ToTable("UserRoleMapping227");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoleMapping227s)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRoleM__RoleI__571DF1D5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleMapping227s)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRoleM__UserI__5629CD9C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

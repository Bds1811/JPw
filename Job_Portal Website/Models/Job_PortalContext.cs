using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Job_Portal_Website.Models
{
    public partial class Job_PortalContext : DbContext
    {
        public Job_PortalContext()
        {
        }

        public Job_PortalContext(DbContextOptions<Job_PortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<ApplyforJob> ApplyforJobs { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<JobPosting> JobPostings { get; set; } = null!;
        public virtual DbSet<JobSeeker> JobSeekers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-B5DHM03O\\SQLExpress;Database=Job_Portal;Trusted_Connection=True;TrustServerCertificate=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.HasIndex(e => e.Email, "UQ__Admin__A9D105345E3B6181")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplyforJob>(entity =>
            {
                entity.HasKey(e => e.AppliedJobld)
                    .HasName("PK__Applyfor__AF1B2E39978D763E");

                entity.Property(e => e.JobSeekerId).HasColumnName("Job_SeekerId");

                entity.Property(e => e.Resume)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompanyldNavigation)
                    .WithMany(p => p.ApplyforJobs)
                    .HasForeignKey(d => d.Companyld)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ApplyforJ__Compa__32E0915F");

                entity.HasOne(d => d.JobSeeker)
                    .WithMany(p => p.ApplyforJobs)
                    .HasForeignKey(d => d.JobSeekerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__ApplyforJ__Job_S__30F848ED");

                entity.HasOne(d => d.JobldNavigation)
                    .WithMany(p => p.ApplyforJobs)
                    .HasForeignKey(d => d.Jobld)
                    .HasConstraintName("FK__ApplyforJ__Jobld__31EC6D26");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Companyld)
                    .HasName("PK__Company__2D9628F7B78CCEBD");

                entity.ToTable("Company");

                entity.HasIndex(e => e.CompanyEmail, "UQ__Company__A1DB68DBD740EEAE")
                    .IsUnique();

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Companyphone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JobPosting>(entity =>
            {
                entity.HasKey(e => e.Jobld)
                    .HasName("PK__JobPosti__0567949CF7F0A84B");

                entity.ToTable("JobPosting");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.IpLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ip_location");

                entity.Property(e => e.JobDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.JobExperienceLevel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobPayScale)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobSkillSet)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CompanyldNavigation)
                    .WithMany(p => p.JobPostings)
                    .HasForeignKey(d => d.Companyld)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__JobPostin__Compa__2E1BDC42");
            });

            modelBuilder.Entity<JobSeeker>(entity =>
            {
                entity.ToTable("Job_Seeker");

                entity.HasIndex(e => e.Email, "UQ__Job_Seek__A9D105344A442709")
                    .IsUnique();

                entity.Property(e => e.JobSeekerId).HasColumnName("Job_SeekerId");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Skills)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

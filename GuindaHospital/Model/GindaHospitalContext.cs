using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GuindaHospital.Model;

public partial class GindaHospitalContext : DbContext
{
    public GindaHospitalContext()
    {
    }

    public GindaHospitalContext(DbContextOptions<GindaHospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<Insurace> Insuraces { get; set; }

    public virtual DbSet<Msc> Mscs { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=GindaHospital;User Id=Jhonn;Password=qwerty; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RegisteredDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((1))")
                .HasComment("1 = Active\r\n0 = Inactive");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Doctor");

            entity.HasOne(d => d.IdDoctor1).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Patient");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RegisteredDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Insurace>(entity =>
        {
            entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RegisteredDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((1))")
                .HasComment("1 = Active\r\n0 = Inactive\r\n");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.Insuraces)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Insurace_Patient");
        });

        modelBuilder.Entity<Msc>(entity =>
        {
            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Mscs).HasConstraintName("FK_Msc_Doctor");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(e => e.Genre).IsFixedLength();
            entity.Property(e => e.LastUpdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RegisteredDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((1))")
                .HasComment("1 = Active\r\n0 = Inactive\r\n");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Prescriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Doctor");

            entity.HasOne(d => d.IdDrugNavigation).WithMany(p => p.Prescriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Drugs");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.Prescriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Patient");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

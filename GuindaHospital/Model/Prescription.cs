using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GuindaHospital.Model;

[Table("Prescription")]
public partial class Prescription
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("idDrug")]
    public int IdDrug { get; set; }

    [Column("description")]
    [StringLength(100)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [Column("idPatient")]
    public int IdPatient { get; set; }

    [Column("idDoctor")]
    public int IdDoctor { get; set; }

    [ForeignKey("IdDoctor")]
    [InverseProperty("Prescriptions")]
    public virtual Doctor IdDoctorNavigation { get; set; } = null!;

    [ForeignKey("IdDrug")]
    [InverseProperty("Prescriptions")]
    public virtual Drug IdDrugNavigation { get; set; } = null!;

    [ForeignKey("IdPatient")]
    [InverseProperty("Prescriptions")]
    public virtual Patient IdPatientNavigation { get; set; } = null!;
}

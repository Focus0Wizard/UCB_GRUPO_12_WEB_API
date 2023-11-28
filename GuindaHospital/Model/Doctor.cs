using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GuindaHospital.Model;

[Table("Doctor")]
public partial class Doctor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("lastName")]
    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("secondLastName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SecondLastName { get; set; }

    [Column("phoneNumber")]
    [StringLength(8)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column("status")]
    public int Status { get; set; }

    [Column("registeredDate", TypeName = "datetime")]
    public DateTime RegisteredDate { get; set; }

    [Column("lastUpdate", TypeName = "datetime")]
    public DateTime? LastUpdate { get; set; }

    [InverseProperty("IdDoctorNavigation")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [InverseProperty("IdDoctorNavigation")]
    public virtual ICollection<Msc> Mscs { get; set; } = new List<Msc>();

    [InverseProperty("IdDoctorNavigation")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}

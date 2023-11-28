using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GuindaHospital.Model;

[Table("Patient")]
public partial class Patient
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

    [Column("secondLastrName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SecondLastrName { get; set; }

    [Column("genre")]
    [StringLength(1)]
    [Unicode(false)]
    public string Genre { get; set; } = null!;

    [Column("b_date", TypeName = "datetime")]
    public DateTime BDate { get; set; }

    [Column("address")]
    [StringLength(100)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [Column("phoneNumber")]
    [StringLength(8)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    /// <summary>
    /// 1 = Active
    /// 0 = Inactive
    /// 
    /// </summary>
    [Column("status")]
    public int Status { get; set; }

    [Column("registeredDate", TypeName = "datetime")]
    public DateTime RegisteredDate { get; set; }

    [Column("lastUpdate", TypeName = "datetime")]
    public DateTime? LastUpdate { get; set; }

    [InverseProperty("IdDoctor1")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [InverseProperty("IdPatientNavigation")]
    public virtual ICollection<Insurace> Insuraces { get; set; } = new List<Insurace>();

    [InverseProperty("IdPatientNavigation")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}

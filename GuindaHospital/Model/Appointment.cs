using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GuindaHospital.Model;

[Table("Appointment")]
public partial class Appointment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("date", TypeName = "datetime")]
    public DateTime Date { get; set; }

    /// <summary>
    /// 1 = Active
    /// 0 = Inactive
    /// </summary>
    [Column("status")]
    public int Status { get; set; }

    [Column("registeredDate", TypeName = "datetime")]
    public DateTime RegisteredDate { get; set; }

    [Column("lastUpdate", TypeName = "datetime")]
    public DateTime? LastUpdate { get; set; }

    [Column("idDoctor")]
    public int IdDoctor { get; set; }

    [Column("idPatient")]
    public int IdPatient { get; set; }

    [ForeignKey("IdDoctor")]
    [InverseProperty("Appointments")]
    public virtual Patient? IdDoctor1 { get; set; }

    [ForeignKey("IdDoctor")]
    [InverseProperty("Appointments")]
    public virtual Doctor? IdDoctorNavigation { get; set; }
}

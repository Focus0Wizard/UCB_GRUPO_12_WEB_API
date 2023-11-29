using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GuindaHospital.Model;

[Table("Insurace")]
public partial class Insurace
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("info")]
    [Unicode(false)]
    public string Info { get; set; } = null!;

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

    [Column("idPatient")]
    public int IdPatient { get; set; }

    [ForeignKey("IdPatient")]
    [InverseProperty("Insuraces")]
    public virtual Patient? IdPatientNavigation { get; set; } 
}

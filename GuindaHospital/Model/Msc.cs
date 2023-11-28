using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GuindaHospital.Model;

[Table("Msc")]
public partial class Msc
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(40)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("idDoctor")]
    public int? IdDoctor { get; set; }

    [ForeignKey("IdDoctor")]
    [InverseProperty("Mscs")]
    public virtual Doctor? IdDoctorNavigation { get; set; }
}

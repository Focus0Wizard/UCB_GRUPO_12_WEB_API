using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GuindaHospital.Model;

public partial class Drug
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("molGrams")]
    [StringLength(50)]
    [Unicode(false)]
    public string MolGrams { get; set; } = null!;

    [InverseProperty("IdDrugNavigation")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}

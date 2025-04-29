using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prj_core_withdbfirstapproch.MyModels;

[Index("DifficultyId", Name = "IX_Walks_DifficultyId")]
[Index("RegionId", Name = "IX_Walks_RegionId")]
public partial class Walk
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double LengthInKm { get; set; }

    public string? WalksImageUrl { get; set; }

    public Guid DifficultyId { get; set; }

 //   public Guid RegionId { get; set; }

    [ForeignKey("DifficultyId")]
    [InverseProperty("Walks")]
    public virtual Difficulty Difficulty { get; set; } = null!;

    [ForeignKey("RegionId")]
    [InverseProperty("Walks")]
    public virtual Region Region { get; set; } = null!;
}

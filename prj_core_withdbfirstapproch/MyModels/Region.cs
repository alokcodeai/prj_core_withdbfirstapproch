using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prj_core_withdbfirstapproch.MyModels;

public partial class Region
{
    [Key]
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? RegionImageUrl { get; set; }

    [InverseProperty("Region")]
    public virtual ICollection<Walk> Walks { get; set; } = new List<Walk>();
}

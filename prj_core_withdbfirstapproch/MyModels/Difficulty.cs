using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prj_core_withdbfirstapproch.MyModels;

public partial class Difficulty
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    [InverseProperty("Difficulty")]
    public virtual ICollection<Walk> Walks { get; set; } = new List<Walk>();
}

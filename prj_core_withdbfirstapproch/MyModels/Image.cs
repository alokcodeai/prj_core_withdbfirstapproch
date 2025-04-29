using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prj_core_withdbfirstapproch.MyModels;

public partial class Image
{
    [Key]
    public Guid Id { get; set; }

    public string FileName { get; set; } = null!;

    public string? FileDescription { get; set; }

    public string FileExtension { get; set; } = null!;

    public long FileSizeInBytes { get; set; }

    public string FilePath { get; set; } = null!;
}

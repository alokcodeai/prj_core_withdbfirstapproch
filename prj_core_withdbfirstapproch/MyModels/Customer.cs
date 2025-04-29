using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prj_core_withdbfirstapproch.MyModels;

[Table("customer")]
public partial class Customer : BaseEntity
{
    //[NotMapped]
    //public int Id { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    public string? FirstName { get; set; }

    [Column("last_name")]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Column("mobile")]
    [StringLength(50)]
    public string? Mobile { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string? Email { get; set; }

    [InverseProperty("Cust")]
    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    [InverseProperty("Cust")]
    public virtual ICollection<CustomerBank> CustomerBanks { get; set; } = new List<CustomerBank>();
}

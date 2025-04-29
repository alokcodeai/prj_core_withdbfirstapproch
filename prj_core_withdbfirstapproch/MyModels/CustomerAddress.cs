using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prj_core_withdbfirstapproch.MyModels;

[Table("customer_address")]
public partial class CustomerAddress
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("cust_id")]
    public int? CustId { get; set; }

    [Column("house_no")]
    [StringLength(50)]
    public string? HouseNo { get; set; }

    [Column("street_no")]
    [StringLength(50)]
    public string? StreetNo { get; set; }

    [Column("area")]
    [StringLength(50)]
    public string? Area { get; set; }

    [Column("pincode")]
    [StringLength(50)]
    public string? Pincode { get; set; }

    [Column("city")]
    [StringLength(50)]
    public string? City { get; set; }

    [Column("country")]
    [StringLength(50)]
    public string? Country { get; set; }

    [ForeignKey("CustId")]
    [InverseProperty("CustomerAddresses")]
    public virtual Customer? Cust { get; set; }
}

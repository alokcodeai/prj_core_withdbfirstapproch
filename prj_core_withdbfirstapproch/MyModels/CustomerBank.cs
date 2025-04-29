using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prj_core_withdbfirstapproch.MyModels;

[Table("customer_bank")]
public partial class CustomerBank
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("cust_id")]
    public int? CustId { get; set; }

    [Column("bank_name")]
    [StringLength(50)]
    public string? BankName { get; set; }

    [Column("account_no")]
    [StringLength(50)]
    public string? AccountNo { get; set; }

    [Column("ifsc_code")]
    [StringLength(50)]
    public string? IfscCode { get; set; }

    [Column("upi")]
    [StringLength(50)]
    public string? Upi { get; set; }

    [Column("imps")]
    [StringLength(50)]
    public string? Imps { get; set; }

    [ForeignKey("CustId")]
    [InverseProperty("CustomerBanks")]
    public virtual Customer? Cust { get; set; }
}

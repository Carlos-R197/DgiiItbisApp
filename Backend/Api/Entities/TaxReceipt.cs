using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Api.Entities;

public class TaxReceipt
{
    [ForeignKey("Contributor")]
    [StringLength(11)]
    public string RncIdentificationCard { get; set; } = "";
    [Key]
    public string NCF { get; set; } = "";
    [Precision(18, 2)]
    public decimal Amount { get; set; }
    [Precision(18, 2)]
    public decimal Itbis18 { get; set; }
}
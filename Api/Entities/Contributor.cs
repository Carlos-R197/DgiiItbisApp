using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Api.Entities;

public class Contributor
{
    [Key]
    [StringLength(11)]
    public string RncIdentificationCard { get; set; } = "";
    [StringLength(100)]
    public string Name { get; set; } = "";
    [StringLength(50)]
    public string Type { get; set; } = "";
    public bool Active { get; set; }
}
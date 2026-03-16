using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesAutomobile.Models;

public class Automobile
{
    public int Id { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal MSRP { get; set; }
}
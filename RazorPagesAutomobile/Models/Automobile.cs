using System.ComponentModel.DataAnnotations;

namespace RazorPagesAutomobile.Models;

public class Automobile
{
    public int Id { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public decimal MSRP { get; set; }
}
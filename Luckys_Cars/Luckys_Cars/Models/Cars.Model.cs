using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Luckys_Cars.Models;

public class Cars_Model
{
    [Key]
    public int ItemId { get; set; }   // primary key for cars
    public string ExtColor { get; set; }  // Exterior color
    public string IntColor { get; set; }  // interior color
    public int Miles { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Features { get; set; }
    public string Engine { get; set; }
    public string Transmission { get; set; }
    public int Cost { get; set; }
    [ForeignKey("SaleId")]
    public int? SaleId { get; set; }  // foreign key for cars
}
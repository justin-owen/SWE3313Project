using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Luckys_Cars.Models;

public class Cart_Model
{
    [Key]
    public int CartId { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User_Model? User { get; set; }
    public List<Cars_Model> Items { get; set; } = new();
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Luckys_Cars.Models;

public class Sale_Model
{
    [Key]
    public int SaleId { get; set; }
    public int InvPrice { get; set; }   // Uses a multiply and divide system to save decimal numbers
                                        // more accurately in SQLite infrastructure
    public int Tax { get; set; }
    public int Shipping { get; set; }
    public int UserId { get; set; }   //foreign key
    [ForeignKey("UserId")]
    public User_Model? User { get; set; }

}
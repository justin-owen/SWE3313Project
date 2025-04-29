using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Luckys_Cars.Models;

public class CarPhotos_Model
{
    [Key]
    public int ImageId {get; set;}
    [ForeignKey("ItemId")]
    public int ItemId {get; set;}
    [Required]
    public byte[] ImageData {get; set;} = Array.Empty<byte>();

    public Cars_Model Car { get; set; } = null!;
    

}
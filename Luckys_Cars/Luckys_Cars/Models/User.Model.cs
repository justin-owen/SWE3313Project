using System.ComponentModel.DataAnnotations;

namespace Luckys_Cars.Models;

public class User_Model
{
    [Key]
    public int UserId { get; set; }  //primary key for users
    public string Name { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }  // minimum of 6 characters 
    public int IsAdmin { get; set; }   // Uses SQLite Boolean, which is an integer
}
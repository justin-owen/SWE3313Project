
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Luckys_Cars.Models;

namespace Luckys_Cars.Data
{
    public class LuckysDbContext : DbContext
    {
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Sale> Sale { get; set; }

        public LuckysDbContext(DbContextOptions<LuckysDbContext> options) : base(options)
        {
        }
        public DbSet<User_Model> UserModel { get; set; }
    }

    public class Car  // Define your Car class here
    {
        [Key]
        public int ItemId { get; set; }   // primary key for cars
        
        public string extColor { get; set; }  // Exterior color
        public string intColor { get; set; }  // interior color
        public int miles { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int Year { get; set; }
        public string features { get; set; }
        public string engine { get; set; }
        public string transmission { get; set; }
        public int cost { get; set; }
        
        [ForeignKey("saleId")]
        public int saleId { get; set; }  // foreign key for cars
        
    }

    public class Users
    {
        [Key]
        public int UserId { get; set; }  //primary key for users
       
        public string name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }  // minimum of 6 characters 
        public int isAdmin { get; set; }   // Uses SQLite Boolean, which is an integer
    }

    public class Sale
    {
        [Key]
        public int saleId { get; set; }
        
        public int invPrice { get; set; }   // Uses a multiply and divide system to save decimal numbers
                                            // more accurately in SQLite infrastructure
        public int tax { get; set; }
        public int shipping { get; set; }
        public int userId { get; set; }   //foreign key
        
    }
    
    
    
    
    
    
}


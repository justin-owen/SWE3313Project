
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Luckys_Cars.Models;

namespace Luckys_Cars.Data
{
    public class LuckysDbContext : DbContext
    {
        
        public DbSet<Cars_Model> Cars { get; set; }
        public DbSet<User_Model> Users { get; set; }
        public DbSet<Sale_Model> Sale { get; set; }
        public DbSet<CarPhotos_Model> CarPhotos { get; set; }

        public LuckysDbContext(DbContextOptions<LuckysDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars_Model>().HasData(
                new Cars_Model
                {
                    ItemId = 00001,
                    ExtColor = "Red",
                    IntColor = "Black",
                    Miles = 95151,
                    Make = "Ford",
                    Model = "Mustang GT Premium",
                    Year = 2012,
                    Features = "Steering Wheel Audio Controls, " +
                               "Satellite and Bluetooth Radio, " +
                               "Keyless Entry, Traction Control, " +
                               "Rear Spoiler",
                    Engine = "5.0L V8 412hp",
                    Transmission = "Manual 6 Speed",
                    Cost = 1750000,
                    SaleId = null
                },
                new Cars_Model
                {
                    ItemId = 00002,
                    ExtColor = "Black",
                    IntColor = "Black",
                    Miles = 10898,
                    Make = "Honda",
                    Model = "Accord Sport",
                    Year = 2022,
                    Features = "Bluetooth Radio, Automatic Climate Control",
                    Engine = "1.5L Turbo I4 192 hp",
                    Transmission = "CVT",
                    Cost = 1899999,
                    SaleId = null
                },
                new Cars_Model
                {
                    ItemId = 00003,
                    ExtColor = "White",
                    IntColor = "Cement",
                    Miles = 28214,
                    Make = "Toyota",
                    Model = "Tacoma",
                    Year = 2021,
                    Features = "Audio Controls on Steering Wheel," +
                               " Bluetooth Radio," +
                               " Climate Control," +
                               " Heated Mirrors",
                    Engine = "3.5L V6",
                    Transmission = "Automatic 6 Speed",
                    Cost = 3199500,
                    SaleId = null
                },
                new Cars_Model
                {
                    ItemId = 00004,
                    ExtColor = "Red",
                    IntColor = "Black",
                    Miles = 94400,
                    Make = "Mercedes-Benz",
                    Model = "C-Class C 300 Sport",
                    Year = 2013,
                    Features = "Moonroof," +
                               " Bluetooth Audio," +
                               " Audio Controls on Steering Wheel",
                    Engine = "3.5L V6",
                    Transmission = "Automatic 7 Speed",
                    Cost = 899500,
                    SaleId = null
                }
                );
            modelBuilder.Entity<User_Model>().HasData(
                    new User_Model
                    {
                        UserId = 00001,
                        Name = "Developer",
                        Email = "wlane12@students.kennesaw.edu",
                        Password = "SillyHill795",
                        Username = "Developer_Admin",
                        IsAdmin = 1
                    },
                    new User_Model
                    {
                        UserId = 00002,
                        Name = "Jeff Adkisson",
                        Email = "JAdkiss1@kennesaw.edu",
                        Password = "SecretPassword3313",
                        Username = "JAdkiss1",
                        IsAdmin = 1
                    }
                );
            
            //Key relationships
            modelBuilder.Entity<Cars_Model>()
                .HasOne(c => c.Sale)
                .WithMany() 
                .HasForeignKey(c => c.SaleId);  
            modelBuilder.Entity<Sale_Model>()
                .HasMany(s => s.Items)
                .WithOne(c => c.Sale)
                .HasForeignKey(c => c.SaleId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CarPhotos_Model>()
                .HasOne(cp => cp.Car)
                .WithMany()
                .HasForeignKey(cp => cp.ItemId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
    
    
    
    
}


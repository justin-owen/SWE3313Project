using Luckys_Cars.Data;
using Luckys_Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Luckys_Cars;


public class DataService
{
    private readonly LuckysDbContext _context;

    public DataService(LuckysDbContext context)
    {
        _context=context;
    }

    public async Task<List<Cars_Model>> GetCars()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task AddCar(Cars_Model car)
    {
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<User_Model>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<(bool Success, string Message)> AddUser(User_Model user)
    {
        bool usernameExists = await _context.Users.AnyAsync(u => u.Username == user.Username);
        if (usernameExists)
        {
            return (false, "Username already exists");
        }

        bool emailExists = await _context.Users.AnyAsync(u => u.Email == user.Email);
        if (emailExists)
        {
            return (false, "Email already exists");
        }

        if (string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 7)
        {
            return (false, "Password must be greater than 6 characters");
        }
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return (true, "");

    }
    public async Task<List<Sale_Model>> GetSales()
    {
        return await _context.Sale.ToListAsync();
    }

    public async Task AddSale(Sale_Model sale)
    {
        await _context.SaveChangesAsync();
    }
    
}
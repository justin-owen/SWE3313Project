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

    public async Task<Cars_Model> AddCar(Cars_Model car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
        return car;
    }
    
    public async Task<Cars_Model?> GetCarById(int itemId)
    {
        return await _context.Cars
            .FirstOrDefaultAsync(c => c.ItemId == itemId);
    }
    
    public async Task<List<User_Model>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    
    public async Task<User_Model?> GetUserById(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }
    
    
    public async Task SetUserAdminStatus(int userId, bool isAdmin)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null)
        {
            user.IsAdmin = isAdmin ? 1 : 0;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteUser(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
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

    public async Task<List<CarPhotos_Model>> GetPhotos()
    {
        return await _context.CarPhotos.ToListAsync();
    }


    public async Task<List<CarPhotos_Model>> GetPhotosByCar(int itemId)
    {
        return await _context.CarPhotos
            .Where(p => p.ItemId == itemId)
            .ToListAsync();
    }


    public async Task AddPhoto(CarPhotos_Model photo)
    {
        _context.CarPhotos.Add(photo);
        await _context.SaveChangesAsync();
    }


    public async Task<bool> DeletePhoto(int photoId)
    {
        var photo = await _context.CarPhotos.FindAsync(photoId);
        if (photo == null)
        {
            return false;
        }
        _context.CarPhotos.Remove(photo);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<CarPhotos_Model?> GetPrimaryPhoto(int itemId)
    {
        return await _context.CarPhotos
            .Where(p => p.ItemId == itemId)
            .OrderBy(p => p.ImageId)
            .FirstOrDefaultAsync();
    }
    public async Task AddCarPhoto(CarPhotos_Model photo)
    {
        _context.CarPhotos.Add(photo);
        await _context.SaveChangesAsync();
    }
}
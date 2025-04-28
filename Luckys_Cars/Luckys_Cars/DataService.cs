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
        return await _context;
    }
}
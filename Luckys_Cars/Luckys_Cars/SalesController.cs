using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Luckys_Cars.Data; // Update to match your actual namespace
using Luckys_Cars.Models; // Assuming Sale_Model and Cars_Model live here

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly LuckysDbContext _context;

    public SalesController(LuckysDbContext context)
    {
        _context = context;
    }

    [HttpGet("export")]
    public async Task<IActionResult> Export()
    {
        var sales = await _context.Sale
            .Include(s => s.Items)
            .ToListAsync();

        var csv = new StringBuilder();
        csv.AppendLine("SaleId,DateCompleted,TotalPrice,CarId,Make,Model,Year,Price");

        foreach (var sale in sales)
        {
            foreach (var car in sale.Items)
            {
                csv.AppendLine($"{sale.SaleId},{sale.InvPrice}," +
                               $"{car.ItemId},{car.Make},{car.Model},{car.Year},{car.Cost}");
            }
        }

        var bytes = Encoding.UTF8.GetBytes(csv.ToString());
        return File(bytes, "text/csv", "SalesExport.csv");
    }
}
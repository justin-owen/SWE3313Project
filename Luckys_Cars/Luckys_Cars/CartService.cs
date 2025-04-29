using Luckys_Cars.Data;
using Luckys_Cars.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class CartService
{
    private readonly LuckysDbContext _dbContext;
    private readonly AuthenticationStateProvider _authProvider;

    public CartService(LuckysDbContext dbContext, AuthenticationStateProvider authProvider)
    {
        _dbContext = dbContext;
        _authProvider = authProvider;
    }

    public async Task<bool> AddItemToCartAsync(Cars_Model car)
    {
        var authState = await _authProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (!user.Identity.IsAuthenticated)
            return false;

        var userIdString = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdString))
            return false;

        int userId = int.Parse(userIdString);

        // Check if there is an incomplete Sale for this user
        var sale = await _dbContext.Sale
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.UserId == userId && s.Completed == false);

        if (sale == null)
        {
            // No open sale — create one
            sale = new Sale_Model
            {
                UserId = userId,
                Completed = false,
                Items = new List<Cars_Model>(),
                InvPrice = 0, // will calculate after adding
                Tax = 0,
                Shipping = 0
            };

            _dbContext.Sale.Add(sale);
        }

        // Add the car to the sale
        sale.Items.Add(car);

        // Recalculate InvPrice
        sale.InvPrice = sale.Items.Sum(c => c.Cost);

        await _dbContext.SaveChangesAsync();

        return true;
    }
}
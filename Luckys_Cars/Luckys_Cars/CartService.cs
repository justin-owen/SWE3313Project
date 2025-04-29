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

    // Adds an item to the current user's cart
    public async Task<bool> AddItemToCartAsync(int itemId)
    {
        var userId = await GetCurrentUserIdAsync();

        // Get or create the user's open Sale
        var sale = await _dbContext.Sale
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.UserId == userId && !s.Completed);

        if (sale == null)
        {
            sale = new Sale_Model
            {
                UserId = userId,
                Completed = false,
                Items = new List<Cars_Model>()
            };
            _dbContext.Sale.Add(sale);
            await _dbContext.SaveChangesAsync(); // Save to generate SaleId
        }

        var car = await _dbContext.Cars.FirstOrDefaultAsync(c => c.ItemId == itemId);

        if (car == null)
        {
            Console.WriteLine($"[DEBUG] No car found with ItemId {itemId}");
            return false;
        }

        // Only add if not already part of a Sale
        if (car.SaleId != sale.SaleId)
        {
            car.SaleId = sale.SaleId;
            await _dbContext.SaveChangesAsync();
            Console.WriteLine($"[DEBUG] Added ItemId {itemId} to SaleId {sale.SaleId}");
        }

        return true;
    }

    // Loads the current Sale (Cart) for the user
    public async Task<Sale_Model?> GetCurrentSaleAsync()
    {
        var userId = await GetCurrentUserIdAsync();

        return await _dbContext.Sale
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.UserId == userId && !s.Completed);
    }

    // Marks the Sale as Complete
    public async Task CompleteSaleAsync(int saleId)
    {
        var sale = await _dbContext.Sale.FindAsync(saleId);

        if (sale != null)
        {
            sale.Completed = true;
            await _dbContext.SaveChangesAsync();
        }
    }

    // Removes an item from the cart
    public async Task<bool> RemoveItemFromCartAsync(int itemId)
    {
        var item = await _dbContext.Cars.FirstOrDefaultAsync(c => c.ItemId == itemId && c.SaleId != null);
        if (item != null)
        {
            item.SaleId = null; // Remove from Sale
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    // Gets the authenticated user's integer ID
    private async Task<int> GetCurrentUserIdAsync()
    {
        var authState = await _authProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            var userIdStr = user.FindFirst(c => c.Type == "sub")?.Value
                         ?? user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(userIdStr) && int.TryParse(userIdStr, out int userId))
            {
                return userId;
            }
        }

        throw new InvalidOperationException("User is not authenticated or no valid integer UserId found.");
    }
}

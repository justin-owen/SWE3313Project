using Luckys_Cars.Data;
using Luckys_Cars.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Luckys_Cars.Components.Pages;

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

        var cart = await _dbContext.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            cart = new Cart_Model
            {
                UserId = userId,
                Items = new List<Cars_Model>()
            };
            _dbContext.Carts.Add(cart);
            await _dbContext.SaveChangesAsync();
        }

        var car = await _dbContext.Cars.FirstOrDefaultAsync(c => c.ItemId == itemId);
        if (car == null)
        {
            Console.WriteLine($"[DEBUG] No car found with ItemId {itemId}");
            return false;
        }

        // Avoid duplicate entries
        if (!cart.Items.Any(c => c.ItemId == itemId))
        {
            cart.Items.Add(car);
            await _dbContext.SaveChangesAsync();
            Console.WriteLine($"[DEBUG] Added ItemId {itemId} to CartId {cart.CartId}");
        }

        return true;
    }

    // Loads the current cart for the user
    public async Task<Cart_Model?> GetCurrentCartAsync()
    {
        var userId = await GetCurrentUserIdAsync();

        var cart = await _dbContext.Carts
            .AsNoTracking()
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            Console.WriteLine("[DEBUG] No active cart found for user.");
        }
        else
        {
            Console.WriteLine($"[DEBUG] Active cart found: CartId={cart.CartId}, Items count={cart.Items.Count}");
        }

        return cart;
    }

    // Removes an item from the cart
    public async Task<bool> RemoveItemFromCartAsync(int itemId)
    {
        var userId = await GetCurrentUserIdAsync();

        var cart = await _dbContext.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            Console.WriteLine("[DEBUG] No active cart found for user.");
            return false;
        }

        var item = cart.Items.FirstOrDefault(i => i.ItemId == itemId);

        if (item == null)
        {
            Console.WriteLine("[DEBUG] Item not found in current user's cart.");
            return false;
        }

        cart.Items.Remove(item);
        await _dbContext.SaveChangesAsync();
        Console.WriteLine($"[DEBUG] Removed ItemId={itemId} from CartId={cart.CartId}");
        return true;
    }
    
    public async Task CompleteSaleAsync(int cartId)
    {
        var cart = await _dbContext.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.CartId == cartId);

        if (cart == null || cart.Items.Count == 0)
        {
            Console.WriteLine("[DEBUG] Cart not found or empty.");
            return;
        }

        int subtotal = 0;
        foreach (var car in cart.Items)
        {
            subtotal += car.Cost;
        }
        
        decimal taxRate = 0.07m;
        int tax = (int)Math.Round(subtotal * taxRate);
        
        int shipping = 0;
        if (cart.Items.Count == 1)
        {
            shipping = 0;
        }
        else if (cart.Items.Count == 2)
        {
            shipping = 1900;
        }
        else
        {
            shipping = 2900;
        }

        //Create Sale
        var sale = new Sale_Model
        {
            UserId = cart.UserId,
            Completed = true,
            InvPrice = subtotal,
            Tax = tax,
            Shipping = shipping,
            Items = new List<Cars_Model>()
        };

        _dbContext.Sale.Add(sale);
        await _dbContext.SaveChangesAsync();

        Console.WriteLine($"[DEBUG] New Sale created: SaleId={sale.SaleId}, Subtotal={subtotal}, Tax={tax}, Shipping={shipping}");

        //Link Cars to Sale
        foreach (var car in cart.Items)
        {
            car.SaleId = sale.SaleId;
            sale.Items.Add(car);
        }

        await _dbContext.SaveChangesAsync();
        Console.WriteLine($"[DEBUG] Cars updated with new SaleId={sale.SaleId}");

        //Remove Cart
        _dbContext.Carts.Remove(cart);
        await _dbContext.SaveChangesAsync();
        Console.WriteLine($"[DEBUG] CartId={cartId} removed after checkout.");
    }




    // Gets the authenticated user's ID
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

using Luckys_Cars ;
using Luckys_Cars.Components;
using Microsoft.EntityFrameworkCore;
using Luckys_Cars.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthentication("Identity.Application")
    .AddCookie("Identity.Application", options => { options.LoginPath = "/"; });
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();





//Register Db Context
builder.Services.AddDbContext<LuckysDbContext>(options =>
    options.UseSqlite("Data Source=Luckys.db"));
builder.Services.AddScoped<DataService>();

builder.Services.AddScoped<CartService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<Authenticator>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<Authenticator>());
builder.Services.AddScoped<CartStateService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    
    
    app.UseExceptionHandler(errorApp => errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("An unexpected error occurred.");
    }));
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization(); 

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapPost("/api/login", async (HttpContext context, DataService dataService) =>
{
    Console.WriteLine("[DEBUG] /api/login hit.");
    
    var form = await context.Request.ReadFormAsync();
    var usernameOrEmail = form["userIdInput"].ToString();
    var password = form["userPassword"].ToString();
    
    Console.WriteLine($"[DEBUG] Login attempt for: {usernameOrEmail}");

    var users = await dataService.GetUsers();

    var loginAttempt = users.FirstOrDefault(u =>
        (u.Username.Equals(usernameOrEmail.Trim(), StringComparison.OrdinalIgnoreCase)
         || u.Email.Equals(usernameOrEmail.Trim(), StringComparison.OrdinalIgnoreCase))
        && u.Password == password);

    if (loginAttempt != null)
    {
        Console.WriteLine($"[DEBUG] User matched: {loginAttempt.Username} / {loginAttempt.Email}");
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, loginAttempt.UserId.ToString()),
            new Claim(ClaimTypes.Name, loginAttempt.Name ?? loginAttempt.Username),
            new Claim(ClaimTypes.Email, loginAttempt.Email ?? "")
        };

        var identity = new ClaimsIdentity(claims, "Identity.Application");
        var principal = new ClaimsPrincipal(identity);

        await context.SignInAsync("Identity.Application", principal);

        Console.WriteLine("[DEBUG] SignInAsync completed, cookie should be issued.");
        
        return Results.Ok();
    }
    else
    {
        Console.WriteLine("[DEBUG] Login failed, user not found or password incorrect.");
        return Results.Unauthorized();
    }
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
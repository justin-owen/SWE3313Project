using Luckys_Cars ;
using Luckys_Cars.Components;
using Microsoft.EntityFrameworkCore;
using Luckys_Cars.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Register Db Context
builder.Services.AddDbContext<LuckysDbContext>(options =>
    options.UseSqlite("Data Source=Luckys.db"));
builder.Services.AddScoped<DataService>();

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

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
//app.MapRazorPages();

app.Run();
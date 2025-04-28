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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
using week7Day3.Models;
using week7Day3.Repos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Register DI
builder.Services.AddScoped<IContactService<ContactInfo>, ContactService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
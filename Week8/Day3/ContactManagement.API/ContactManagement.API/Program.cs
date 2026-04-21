using ContactManagement.API.DataAccess;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register Repository
builder.Services.AddSingleton<IContactRepo, ContactRepo>();

var app = builder.Build();

app.MapControllers();

app.Run();

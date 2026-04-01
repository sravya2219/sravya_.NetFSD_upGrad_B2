using TagHelpersAndRouting.DataAccess;
using TagHelpersAndRouting.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddScoped<IContactService<ContactInfo>, ContactService>();

var app = builder.Build();
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();//To enable attrivute based routing
});

app.Run();

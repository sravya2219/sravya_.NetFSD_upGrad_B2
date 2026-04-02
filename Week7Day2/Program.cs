using StudentDemo.DataAccess;
using StudentDemo.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStudentService<Student>, StudentService>();
builder.Services.AddScoped<ICalculatorService<Calculator>, CalculatorService>();


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

using EFEmployeeAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<EmployeeContext>(opt=> opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

//builder.Configuration.en  Services.En.mvco

//app.UseMvc();

var app = builder.Build();

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});


//app.MapGet("/", () => "Hello World!");

app.Run();



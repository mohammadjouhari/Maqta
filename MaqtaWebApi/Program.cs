using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using NHibernate_Access.Extensions;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
<<<<<<< HEAD
builder.Services.AddTransient<IEmployeeRepositoryAdoNet, RepositoryEmployeeAdoNet>();
=======
>>>>>>> 7f5fe51 (Added my project)
builder.Services.AddDbContextPool<DBContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("HrSoultion"));
    Options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddNHibernate(builder.Configuration.GetConnectionString("HrSoultion"));
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseSwagger(c =>
{
    c.RouteTemplate = "/swagger/{documentName}/swagger.json";
});
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MatqaWebApi"));
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MatqaWebApi");
    c.RoutePrefix = "swagger";
});
app.UseDeveloperExceptionPage();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmployeeController}/{action=list}/{id?}");
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.Run();

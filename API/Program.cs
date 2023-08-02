using API;
using API.Filters;
using API.interfaces;
using API.Service;
using EasyCaching.Memcached;
using Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAdoNetRepository, AdoNetRepository>();
builder.Services.AddTransient<ICacheService, CacheService>();
builder.Services.AddTransient<ISeriLog, SeriLog>();
builder.Services.AddTransient<IDapperRepository, DapperRepository>();
builder.Services.AddTransient<IDbConnection>(db => new SqlConnection(builder.Configuration.GetConnectionString("HrSoultion")));
builder.Services.AddCors();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ExceptionGlobalFilter>();
});
builder.Services.AddDbContextPool<DBContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("HrSoultion"));
    Options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
    Options.EnableSensitiveDataLogging();
});
var app = builder.Build();
var env = app.Services.GetService<Microsoft.AspNetCore.Hosting.IHostingEnvironment>();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
var serilog = app.Services.GetService<ISeriLog>();
app.UseSwagger(c =>
{
    c.RouteTemplate = "/swagger/{documentName}/swagger.json";
});
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API"));
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
    c.RoutePrefix = "swagger";
});
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute( name: "default",pattern: "{controller=EmpController}/{action=list}/{id?}");
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.Run();
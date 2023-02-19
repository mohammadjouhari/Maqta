using API;
using API.Filters;
using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories;
var builder = WebApplication.CreateBuilder(args);
// Register Auto Mapper in code;
builder.Services.AddAutoMapper(typeof(Program));
// This is  how you return xml from accept headrer;
//Accept,application/xml;
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAdoNetRepository, AdoNetRepository>();
builder.Services.AddTransient<ISeriLog, SeriLog>();
// Global Ecxception filter;
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ExceptionGlobalFilter>();
});
builder.Services.AddDbContextPool<DBContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("HrSoultion"));
    Options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
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
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MatqaWebApi"));
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MatqaWebApi");
    c.RoutePrefix = "swagger";
});
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmpController}/{action=list}/{id?}");
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseLogMiddleware();
app.Run();
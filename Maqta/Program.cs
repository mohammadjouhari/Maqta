using Maqta.Services;
using Microsoft.Data.SqlClient;
using System.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IDbConnection>(DbConnection => new SqlConnection(
builder.Configuration.GetConnectionString("HrSoultion")));
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();

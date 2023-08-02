using Microsoft.Data.SqlClient;
using System.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var conncString = builder.Configuration.GetConnectionString("HrSoultion");
builder.Services.AddTransient<IDbConnection>(db => new SqlConnection(conncString);
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseWebSockets();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();

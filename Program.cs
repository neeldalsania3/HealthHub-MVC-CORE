using HealthHub_MVC_CORE;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(Options =>
{
    Options.IdleTimeout = TimeSpan.FromSeconds(36);
});

builder.Services.AddDbContext<HospitalContext>((serviceProvider, options) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//conventioal  routing for MVC controllers
app.MapControllerRoute(
    name: "addamb",
    pattern: "addamb",
    defaults: new {controller="Admin",action="AddAmbulance"});

app.MapControllerRoute(
    name: "vamb",
    pattern: "viewamb",
    defaults: new {controller="Admin",action="ListofAmbulance"});
app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "adanounc",
    pattern: "adann",
    defaults: new {controller="Admin",action="AddAnnouncement"});

app.Run();
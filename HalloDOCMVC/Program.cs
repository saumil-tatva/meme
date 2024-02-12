using HalloDOCMVC.Models;
using Microsoft.EntityFrameworkCore;
using Data_Layer.DataContext;
using Business_Layer.Interface;
using Business_Layer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<ILogin, Login>();
builder.Services.AddScoped<IPatientReq, PatientReq>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Patient_site}/{id?}");

app.Run();

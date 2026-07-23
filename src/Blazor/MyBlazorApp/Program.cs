using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MyBlazorApp.Services;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(o => o.DetailedErrors = true);
builder.Services.AddTelerikBlazor();
builder.Services.AddSingleton<DashboardDataService>();

// CORS policy for ReportsController
// Do NOT do this in your real app, use WithOrigin('yourdomain.com') appropriately
builder.Services.AddCors(corsOption => corsOption
    .AddPolicy("ReportingRestPolicy", corsBuilder => corsBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    ));

// Add services to the container (important: Uses System.Text.Json instead of json.net from now on).
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// ReportsController
builder.Services.TryAddSingleton<IReportServiceConfiguration>(sp => new ReportServiceConfiguration
{
    ReportingEngineConfiguration = sp.GetService<IConfiguration>(),
    HostAppId = "MyBlazorApp",
    Storage = new FileStorage(),
    ReportSourceResolver = new UriReportSourceResolver(Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath, "Reports"))
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapDefaultControllerRoute();
app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");
app.UseCors("ReportingRestPolicy");

app.Run();
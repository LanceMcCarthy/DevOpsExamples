using Microsoft.Extensions.DependencyInjection.Extensions;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(corsOption => corsOption
    // CORS policy for ReportsController
    .AddPolicy("ReportingRestPolicy", corsBuilder => corsBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
));

// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());

// Add Kendo UI services to the services container"
builder.Services.AddKendo();

// Configure dependencies for ReportsController.
builder.Services.TryAddSingleton<IReportServiceConfiguration>(sp =>
    new ReportServiceConfiguration
    {
        ReportingEngineConfiguration = sp.GetService<IConfiguration>(),
        HostAppId = "MyAspNetCoreApp",
        Storage = new FileStorage(),
        ReportSourceResolver = new UriReportSourceResolver(System.IO.Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath, "Reports"))
    });


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
app.UseCors("ReportingRestPolicy");
app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
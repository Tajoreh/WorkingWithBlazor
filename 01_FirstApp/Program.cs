using _01_FirstApp;
using _01_FirstApp.Data;
using _01_FirstApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureOptions<ApplicationSettingsOptions>();

builder.Services.AddHttpClient("employee", (serviceProvider, httpClient) =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<ApplicationSettings>>().Value;

    httpClient.BaseAddress = new Uri(settings.BaseUrl);
});

builder.Services.AddScoped<EmployeeState>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

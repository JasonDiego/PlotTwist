using Models;
using System.Text.Json;
using Services;
using PlotTwist.Services;
using PlotTwist.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = builder.Configuration.GetSection("OpenAISettings").Get<OpenAISettings>();

// scoped: one per HTTP request | transient: always a new instance
builder.Services.AddScoped<IMovieService, JsonFileMovieService>();
builder.Services.AddScoped<IPromptService>(x => ActivatorUtilities.CreateInstance<PromptService>(x, settings.APIKey));
builder.Services.AddRazorPages();
builder.Services.AddControllers();

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

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();

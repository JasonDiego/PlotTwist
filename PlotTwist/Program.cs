using Models;
using System.Text.Json;
using Services;
using PlotTwist.Services;
using PlotTwist.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var apiKey = builder.Configuration.GetValue<string>("OpenAISettings:APIKey");

// Enable dependency injection for OpenAISettings and validate
builder.Services.AddOptions<OpenAISettings>().Bind(builder.Configuration.GetSection("OpenAISettings")).ValidateDataAnnotations();

// scoped: one per HTTP request | transient: always a new instance
builder.Services.AddScoped<IMovieService, JsonFileMovieService>();
builder.Services.AddScoped<IPromptService>(x => ActivatorUtilities.CreateInstance<PromptService>(x, apiKey));
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

using Kolokwium.Models;
using Kolokwium.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MasterContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IAlbumsService, AlbumsService>();
builder.Services.AddScoped<ITracksService, TracksService>();
builder.Services.AddScoped<IMusicianService, MusicianService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


using Microsoft.EntityFrameworkCore;
using YoutubeSearch.Application.Interfaces;
using YoutubeSearch.Application.Services;
using YoutubeSearch.Persistence;
using YoutubeSearch.Persistence.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddScoped<IYoutubeSearchService, YoutubeSearchService>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IYoutubeSearchService, YoutubeSearchService>();

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());
app.MapControllers();
app.Run();


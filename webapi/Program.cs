using flashcardApp.Business;
using FlashcardApp.Data;
using FlashcardApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
const string SpecificOrigins = "_allowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: SpecificOrigins,
      policyBuilder =>
      {
          policyBuilder.WithOrigins("http://localhost:4200", "http://localhost:4200/")
          .AllowAnyHeader()
          .AllowCredentials()
          .AllowAnyMethod();
      });
});

builder.Services.AddScoped<IFlashcardService, FlashcardService>()
                .AddScoped<IEFFlashcardRepo, EFFlashcardRepo>()
                .AddDbContext<DataContext>();

var app = builder.Build();

// use automatic migration
// will create the database if it does not already exist
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<DataContext>();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error attempting to run Migrate: {ex}");
        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(SpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
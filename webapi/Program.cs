using FlashcardApp.Business;
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

// Enforce lowercase routing.
builder.Services.Configure<RouteOptions>(options =>
{
    options.AppendTrailingSlash = true;
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddScoped<IFlashcardService, FlashcardService>()
                .AddScoped<IDeckService, DeckService>()
                .AddScoped<IEFFlashcardRepo, EFFlashcardRepo>()
                .AddScoped<IEFDeckRepo, EFDeckRepo>()
                .AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Use automatic migration
// Will create the database if it does not already exist
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
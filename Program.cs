using Microsoft.EntityFrameworkCore;
using ParkingLot.Data;
using ParkingLot.Services;

var builder = WebApplication.CreateBuilder(args);


//Connecting string variable
var connectionString = builder.Configuration.GetConnectionString("MyDatabaseConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ParkingContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<VehicleService>();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

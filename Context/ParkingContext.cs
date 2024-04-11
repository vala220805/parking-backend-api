using Microsoft.EntityFrameworkCore;
using ParkingLot.Models;

namespace ParkingLot.Data;

public class ParkingContext : DbContext
{
    public ParkingContext(DbContextOptions<ParkingContext> options): base(options)
    {

    }

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

}
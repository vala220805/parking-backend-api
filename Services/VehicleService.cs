using Microsoft.EntityFrameworkCore;
using ParkingLot.Data;
using ParkingLot.Models;

namespace ParkingLot.Services;

public class VehicleService
{
    private readonly ParkingContext _context;

    public VehicleService(ParkingContext parkingContext)
    {
        _context = parkingContext;
    }

    public async Task<IEnumerable<Vehicle>> GetAllVehicles()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task<Vehicle?> GetVehicle(int id)  
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public async Task<Vehicle?> CreateVehicle(Vehicle newVehicle)
    {
        _context.Vehicles.Add(newVehicle);
        await _context.SaveChangesAsync();

        return newVehicle;
    }

    public async Task<Vehicle> UpdateVehicle(int id, Vehicle vehicle)
    {
        var vehicleToUpdate = await _context.Vehicles.FindAsync(id);

        if (vehicleToUpdate == null)
        {
            throw new Exception($"Vehicle {id} was not found.");
        }

        vehicleToUpdate.Brand = vehicle.Brand;
        vehicleToUpdate.CarModel = vehicle.CarModel;
        vehicleToUpdate.Color = vehicle.Color;
        vehicleToUpdate.Plate = vehicle.Plate;
        vehicleToUpdate.Type = vehicle.Type;
        vehicleToUpdate.checkIn = vehicle.checkIn;
        vehicleToUpdate.checkOut = vehicle.checkOut;

        await _context.SaveChangesAsync();

        return vehicle;
    }

    public async Task DeleteVehicle(int id)
    {
        var vehicleToDelete = await _context.Vehicles.FindAsync(id);

        if(vehicleToDelete is null)
        {
            throw new Exception($"Vehicle {id} does not exist");
        }

        _context.Vehicles.Remove(vehicleToDelete);
        await _context.SaveChangesAsync();
    }

}   

namespace ParkingLot.Models;

public class Vehicles
{
    public string Brand { get; set; }

    public string CarModel { get; set; }

    public string Color { get; set; }

    public string Plate { get; set; }

    public VehicleType Type { get; set; }
}

public enum VehicleType
{
    Car,
    Motorcycle
};
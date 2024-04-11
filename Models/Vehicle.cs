
using System.ComponentModel.DataAnnotations;

namespace ParkingLot.Models;

public class Vehicle
{
    [Required]
    public int VehicleId { get; set; }
    [Required]
    public string Brand { get; set; }
    public string CarModel { get; set; }
    [Required]
    public string Color { get; set; }
    [Required]
    public string Plate { get; set; }

    [Required]
    public VehicleType Type { get; set; }

    [Required]
    public DateTime checkIn { get; set; }
    [Required]
    public DateTime checkOut{ get; set; }
}

public enum VehicleType
{
    Car,
    Motorcycle
};
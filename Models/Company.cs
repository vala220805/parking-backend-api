

using System.ComponentModel.DataAnnotations;

namespace ParkingLot.Models;


public class Company
{
    public string Name { get; set; }
    public string Address { get; set; }

    [MaxLength(10)]
    public int Telephone { get; set; }

    public int SpacesMotorcycles { get; set; }

    public int SpacesCars { get; set; }

    
}
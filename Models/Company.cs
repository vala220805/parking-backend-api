

using System.ComponentModel.DataAnnotations;

namespace ParkingLot.Models;


public class Company
{
    public int CompanyId { get; set; }  
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Telephone { get; set; }

    public int NumMotorcycleSpaces { get; set; }

    public int NumCarSpaces { get; set; }


}
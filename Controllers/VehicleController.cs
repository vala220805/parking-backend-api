using ParkingLot.Models;
using Microsoft.AspNetCore.Mvc;
using ParkingLot.Services;

namespace ParkingLot.Controllers;

[Produces("application/json")]
[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{

    VehicleService _service;

    public VehicleController(VehicleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetAll()
    {
        try
        {
            var vehicles = await _service.GetAllVehicles();
            return Ok(vehicles);
        }
        catch (Exception ex)
        {
            return StatusCode(500,$"An error ocurred retrieving all the vehicles \n {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetById(int id)
    {
        try
        {
            var vehicle = await _service.GetVehicle(id);
            return Ok(vehicle);
        }
        catch (Exception ex)
        {
            return StatusCode(500,$"An error ocurred retrieving the vehicle with id {id}  \n {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Vehicle>> Create(Vehicle newVehicle)
    {
        await _service.CreateVehicle(newVehicle);
        return Ok(newVehicle);
        // try
        // {
        //     await _service.CreateVehicle(newVehicle);
        //     return Ok(newVehicle);
        // }
        // catch(Exception ex)
        // {
        //     return StatusCode(500,$"An error ocurred while creating the new Vehicle. \n {ex.Message}");
        // }
    }

    [HttpPut("{id}/vehicle")]
    public async Task<ActionResult<Company>> Update(int id, Vehicle vehicle)
    {
        try
        {
            await _service.UpdateVehicle(id, vehicle);
            return Ok(vehicle);
        }
        catch(Exception ex)
        {
            return StatusCode(500,$"An error ocurred while updating the vehicle. \n {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Vehicle>> Delete(int id)
    {
        try
        {
            await _service.DeleteVehicle(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500,$"An error ocurred while deleting \n {ex.Message}");
        }
    }
}
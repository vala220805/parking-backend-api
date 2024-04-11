using ParkingLot.Models;
using Microsoft.AspNetCore.Mvc;
using ParkingLot.Services;

namespace ParkingLot.Controllers;

[Produces("application/json")]
[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{

    CompanyService _service;

    public CompanyController(CompanyService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Company>>> GetAll()
    {
        try
        {
            var companies = await _service.GetAllCompanies();
            return Ok(companies);
        }
        catch (Exception ex)
        {
            return StatusCode(500,$"An error ocurred retrieving all the companies \n {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Company>> GetById(int id)
    {
        try
        {
            var company = await _service.GetCompany(id);
            return Ok(company);
        }
        catch(Exception ex)
        {
            return StatusCode(500,$"An error ocurred retrieving the compani with id: {id} \n {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Company>> Create(Company newCompany)
    {
        try
        {
            await _service.CreateCompany(newCompany);
            return Ok(newCompany);
        }
        catch(Exception ex)
        {
            return StatusCode(500,$"An error ocurred while creating the company \n {ex.Message}");
        }
    }

    [HttpPut("{id}/company")]
    public async Task<ActionResult<Company>> Update(int id , Company company)
    {
        try
        {
            await _service.UpdateCompany(id, company);
            return Ok(company);
        }
        catch(Exception ex)
        {
            return StatusCode(500,$"An error ocurred updating the company \n {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Company>> Delete(int id)
    {
        try
        {
            await _service.DeleteCompany(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500,$"An error ocurred while deleting the company \n {ex.Message}");
        }
        
    }
}
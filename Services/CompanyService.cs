using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ParkingLot.Data;
using ParkingLot.Models;

namespace ParkingLot.Services;

public class CompanyService
{
    private readonly ParkingContext _context;

    public CompanyService(ParkingContext parkingContext)
    {
        _context = parkingContext;
    }

    public async Task<IEnumerable<Company>> GetAllCompanies()
    {   
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company?> GetCompany(int id)
    {
        return await _context.Companies.FindAsync(id);
    }

    public async Task<Company?> CreateCompany(Company newCompany)
    {
        _context.Companies.Add(newCompany);
        await _context.SaveChangesAsync();

        return newCompany;
    }

    public async Task<Company> UpdateCompany(int companyId, Company company)
    {
        var companyToUpdate = await _context.Companies.FindAsync(companyId);

        if(companyToUpdate is null)
        {
            throw new Exception($"Could not find {companyId}");
        }

        companyToUpdate.Name = company.Name;
        companyToUpdate.Address = company.Address;
        companyToUpdate.Telephone = company.Telephone;
        companyToUpdate.NumMotorcycleSpaces = company.NumMotorcycleSpaces;
        companyToUpdate.NumCarSpaces = company.NumCarSpaces;

        await _context.SaveChangesAsync();

        return company;
    }

    public async Task DeleteCompany(int id)
    {
        var companyToDelete = await _context.Companies.FindAsync(id);

        if(companyToDelete is null)
        {
            throw new Exception($"{nameof(Company)} cannot be deleted");
        }

        _context.Companies.Remove(companyToDelete);
        await _context.SaveChangesAsync();

    }
}
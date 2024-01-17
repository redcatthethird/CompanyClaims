using CompanyClaims.Api.Dtos;
using CompanyClaims.Api.Services;

using Microsoft.AspNetCore.Mvc;

namespace CompanyClaims.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class CompanyController(CompanyService companyService) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<CompanyDetailsDto>> Get()
    {
        var companies = await companyService.GetCompanies();
        return companies.Select(CompanyDetailsDto.From);
    }

    [HttpGet("{id}")]
    public async Task<CompanyDetailsDto?> Get(int id) =>
        CompanyDetailsDto.FromNullable(await companyService.GetCompany(id));

    [HttpGet("{id}/claims")]
    public async Task<IEnumerable<ClaimDetailsDto>?> GetClaims(int id)
    {
        var claims = await companyService.GetClaimsForCompany(id);
        return claims?.Select(ClaimDetailsDto.From);
    }
}

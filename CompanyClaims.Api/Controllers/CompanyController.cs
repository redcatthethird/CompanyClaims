using CompanyClaims.Api.Services;
using CompanyClaims.Core.Models;

using Microsoft.AspNetCore.Mvc;

namespace CompanyClaims.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class CompanyController(CompanyService companyService) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Company> Get() => companyService.GetCompanies();

    [HttpGet("{id}")]
    public Company? Get(int id) => companyService.GetCompany(id);

    [HttpGet("{id}/claims")]
    public IEnumerable<Claim>? GetClaims(int id) => companyService.GetClaimsForCompany(id);
}

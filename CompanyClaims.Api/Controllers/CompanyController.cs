using CompanyClaims.Api.Dtos;
using CompanyClaims.Api.Services;
using CompanyClaims.Core.Models;

using Microsoft.AspNetCore.Mvc;

namespace CompanyClaims.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class CompanyController(CompanyService companyService) : ControllerBase
{
    [HttpGet]
    public IEnumerable<CompanyDetailsDto> Get() => companyService.GetCompanies().Select(CompanyDetailsDto.From);

    [HttpGet("{id}")]
    public CompanyDetailsDto? Get(int id) => CompanyDetailsDto.FromNullable(companyService.GetCompany(id));

    [HttpGet("{id}/claims")]
    public IEnumerable<Claim>? GetClaims(int id) => companyService.GetClaimsForCompany(id);
}

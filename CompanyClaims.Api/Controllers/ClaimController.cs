using CompanyClaims.Api.Dtos;
using CompanyClaims.Api.Services;

using Microsoft.AspNetCore.Mvc;

namespace CompanyClaims.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ClaimController(ClaimService claimService) : ControllerBase
{
    [HttpGet("{ucr}")]
    public async Task<ClaimDetailsDto?> Get(string ucr) =>
        ClaimDetailsDto.FromNullable(await claimService.GetClaim(ucr));

    [HttpPut("{ucr}")]
    public async Task<SuccessDto> Put(string ucr, [FromBody] ClaimUpdateDto claim) =>
        SuccessDto.From(await claimService.TryUpdateClaim(ucr, claim));
}

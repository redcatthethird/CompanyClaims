using CompanyClaims.Core;
using CompanyClaims.Core.Models;

namespace CompanyClaims.Api.Dtos;

public class CompanyDetailsDto : IDto<CompanyDetailsDto, Company>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Address1 { get; set; }
    public required string Address2 { get; set; }
    public required string Address3 { get; set; }
    public required string Postcode { get; set; }
    public required string Country { get; set; }
    public bool IsActive { get; set; }
    public DateTime InsuranceEndDate { get; set; }
    public bool HasActiveInsurancePolicy { get; set; }

    public static CompanyDetailsDto From(Company @base) => new()
    {
        Id = @base.Id,
        Name = @base.Name,
        Address1 = @base.Address1,
        Address2 = @base.Address2,
        Address3 = @base.Address3,
        Postcode = @base.Postcode,
        Country = @base.Country,
        IsActive = @base.IsActive,
        InsuranceEndDate = @base.InsuranceEndDate,
        HasActiveInsurancePolicy = @base.IsActive && @base.InsuranceEndDate > DateTime.Now
    };

    public static CompanyDetailsDto? FromNullable(Company? @base) =>
        @base == null ? default : From(@base);
}

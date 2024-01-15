namespace CompanyClaims.Core.Models;

public class Company
{
    public int Id { get; set; }
    public List<Claim> Claims { get; set; } = [];
    public required string Name { get; set; }
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string Address3 { get; set; } = string.Empty;
    public string Postcode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime InsuranceEndDate { get; set; }
    
    public bool HasActiveInsurancePolicy => IsActive && InsuranceEndDate > DateTime.Now;
}

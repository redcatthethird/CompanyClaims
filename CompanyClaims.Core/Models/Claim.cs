namespace CompanyClaims.Core.Models;

public class Claim
{
    public required string UniqueClaimReference { get; set; }
    public Company Company { get; set; } = null!;
    public DateTime ClaimDate { get; set; } = DateTime.UtcNow;
    public DateTime LossDate { get; set; }
    public string AssuredName { get; set; } = string.Empty;
    public decimal IncurredLoss { get; set; }
    public bool IsClosed { get; set; }
}

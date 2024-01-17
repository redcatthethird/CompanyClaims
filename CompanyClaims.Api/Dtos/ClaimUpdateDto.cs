namespace CompanyClaims.Api.Dtos;

public class ClaimUpdateDto
{
    public DateTime LossDate { get; set; }
    public string AssuredName { get; set; } = string.Empty;
    public decimal IncurredLoss { get; set; }
    public bool IsClosed { get; set; }
}

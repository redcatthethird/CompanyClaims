namespace CompanyClaims.Api.Dtos;

public class ClaimUpdateDto
{
    public DateTime LossDate { get; set; }
    public required string AssuredName { get; set; }
    public decimal IncurredLoss { get; set; }
    public bool IsClosed { get; set; }
}

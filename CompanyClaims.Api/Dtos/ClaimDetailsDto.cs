using CompanyClaims.Core;
using CompanyClaims.Core.Models;

namespace CompanyClaims.Api.Dtos;

public class ClaimDetailsDto : IDto<ClaimDetailsDto, Claim>
{
    public required string UniqueClaimReference { get; set; }
    public required DateTime ClaimDate { get; set; }
    public DateTime LossDate { get; set; }
    public required string AssuredName { get; set; }
    public decimal IncurredLoss { get; set; }
    public bool IsClosed { get; set; }
    public uint AgeInDays { get; set; }

    public static ClaimDetailsDto From(Claim @base) => new()
    {
        UniqueClaimReference = @base.UniqueClaimReference,
        ClaimDate = @base.ClaimDate,
        LossDate = @base.LossDate,
        AssuredName = @base.AssuredName,
        IncurredLoss = @base.IncurredLoss,
        IsClosed = @base.IsClosed,
        AgeInDays = (uint)Math.Floor((DateTime.Now - @base.ClaimDate).TotalDays)
    };

    public static ClaimDetailsDto? FromNullable(Claim? @base) =>
        @base == null ? default : From(@base);
}

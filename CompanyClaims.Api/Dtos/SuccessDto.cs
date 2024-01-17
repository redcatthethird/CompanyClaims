using CompanyClaims.Core;

namespace CompanyClaims.Api.Dtos;

public class SuccessDto : IDto<SuccessDto, bool>
{
    public bool Success { get; set; }

    public static SuccessDto From(bool @base) => new() { Success = @base };

    public static SuccessDto? FromNullable(bool @base) => From(@base);
}

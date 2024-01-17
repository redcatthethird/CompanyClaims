namespace CompanyClaims.Core;

public interface IDto<TDto, TBase> where TDto : IDto<TDto, TBase>
{
    static abstract TDto From(TBase @base);
    static abstract TDto? FromNullable(TBase? @base);
}

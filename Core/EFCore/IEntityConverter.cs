namespace Core.EFCore;

public interface IEntityConverter<TDbo, TDto>
{
    TDbo ToDbo(TDto dto);
    TDto ToDto(TDbo dbo);
}
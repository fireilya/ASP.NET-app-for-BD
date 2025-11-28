using System.Linq;

namespace Core.EFCore;

public static class EntityConverterExtensions
{
    public static TDbo[] ToDbo<TDbo, TDto>(this IEntityConverter<TDbo, TDto> entityConverter, TDto[] dtos) =>
        dtos.Select(entityConverter.ToDbo).ToArray();

    public static TDto[] ToDto<TDbo, TDto>(this IEntityConverter<TDbo, TDto> entityConverter, TDbo[] dbos) =>
        dbos.Select(entityConverter.ToDto).ToArray();
}
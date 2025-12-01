using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IQuestionRepository : IRepository
{
    Task CreateAsync(QuestionDto questionDto);
    Task<QuestionDto?> FindAsync(Guid questionId);
    Task<QuestionDto> ReadAsync(Guid questionId);
    Task<QuestionDto[]> SelectAsync(Guid[] questionIds);
    Task UpdateAsync(QuestionDto questionDto);
    Task DeleteAsync(QuestionDto questionDto);
}

public class QuestionRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<QuestionDbo, QuestionDto> converter
) : RepositoryBase<QuestionDbo, QuestionDto, Guid>(dataContext, converter, x => x.Id), IQuestionRepository
{
    public async Task<QuestionDto> ReadAsync(Guid questionId)
    {
        var questionDbo = await DataContext.ReadAsync<QuestionDbo, Guid>(questionId);
        return Converter.ToDto(questionDbo);
    }
}
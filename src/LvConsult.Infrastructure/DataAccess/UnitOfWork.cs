using LvConsult.Domain.Repositories;

namespace LvConsult.Infrastructure.DataAccess;
internal class UnitOfWork : IUnitOfWork
{
    private readonly LvConsultDbContext _dbContext;
public UnitOfWork(LvConsultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}

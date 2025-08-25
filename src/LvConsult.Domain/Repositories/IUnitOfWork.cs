namespace LvConsult.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}

using LvConsult.Domain.Entities;

namespace LvConsult.Domain.Services.LoggedUser;
public interface ILoggedUser
{
    Task<User> Get();
}

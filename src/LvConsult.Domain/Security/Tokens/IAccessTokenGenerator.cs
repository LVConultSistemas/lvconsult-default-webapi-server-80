using LvConsult.Domain.Entities;

namespace LvConsult.Domain.Security.Tokens;
public interface IAccessTokenGenerator
{
    string Generate(User user);
}

using LvConsult.Communication.Requests;

namespace LvConsult.Application.UseCases.Users.Update;
public interface IUpdateUserUseCase
{
    Task Execute(RequestUpdateUserJson request);
}

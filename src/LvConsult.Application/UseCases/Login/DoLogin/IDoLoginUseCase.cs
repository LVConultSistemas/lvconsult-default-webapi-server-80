using LvConsult.Communication.Requests;
using LvConsult.Communication.Responses;

namespace LvConsult.Application.UseCases.Login.DoLogin;
public interface IDoLoginUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}

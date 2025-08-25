using LvConsult.Communication.Requests;
using LvConsult.Communication.Responses;

namespace LvConsult.Application.UseCases.Users.Register;
public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}

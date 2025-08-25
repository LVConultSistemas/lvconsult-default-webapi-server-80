using LvConsult.Communication.Responses;

namespace LvConsult.Application.UseCases.Users.Profile;
public interface IGetUserProfileUseCase
{
    Task<ResponseUserProfileJson> Execute();
}

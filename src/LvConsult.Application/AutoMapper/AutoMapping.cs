using AutoMapper;
using LvConsult.Communication.Requests;
using LvConsult.Communication.Responses;
using LvConsult.Domain.Entities;

namespace LvConsult.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<User, ResponseUserProfileJson>();
    }
}

using LvConsult.Application.AutoMapper;
using LvConsult.Application.UseCases.Login.DoLogin;
using LvConsult.Application.UseCases.Users.ChangePassword;
using LvConsult.Application.UseCases.Users.Delete;
using LvConsult.Application.UseCases.Users.Profile;
using LvConsult.Application.UseCases.Users.Register;
using LvConsult.Application.UseCases.Users.Update;
using Microsoft.Extensions.DependencyInjection;

namespace LvConsult.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        // Login Use Cases
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
        services.AddScoped<IGetUserProfileUseCase, GetUserProfileUseCase>();

        // User Use Cases
        services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
        services.AddScoped<IDeleteUserAccountUseCase, DeleteUserAccountUseCase>();
    }
}

using Application.Application.Admins;
using Application.Application.Users;
using Application.Contracts.Admins;
using Application.Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAdminService, AdminService>();

        collection.AddScoped<CurrentUserService>();
        collection.AddScoped<CurrentAdminService>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserService>());
        collection.AddScoped<ICurrentAdminService>(
            p => p.GetRequiredService<CurrentAdminService>());

        return collection;
    }
}
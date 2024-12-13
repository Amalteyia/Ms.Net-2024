using AutoMapper;
using DinoPark.BL.Users.Managers;
using DinoPark.BL.Users.Providers;
using DinoPark.DataAccess;
using DinoPark.DataAccess.Entities;
using DinoPark.DataAccess.Repository;
using DinoPark.Service.Settings;
using Microsoft.EntityFrameworkCore;

namespace DinoPark.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services, DinoParkSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        // users
        services.AddScoped<IRepository<UserEntity>>(x =>
            new Repository<UserEntity>(x.GetRequiredService<IDbContextFactory<DinoParkDbContext>>()));
        services.AddScoped<IUsersProvider>(x =>
            new UsersProvider(x.GetRequiredService<IRepository<UserEntity>>(),
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IUsersManager>(x =>
            new UsersManager(x.GetRequiredService<IRepository<UserEntity>>(),
                x.GetRequiredService<IMapper>()));
    }
}
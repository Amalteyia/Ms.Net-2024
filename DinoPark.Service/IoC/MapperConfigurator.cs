using System.Reflection;
using DinoPark.BL.Mapper;
using DinoPark.Service.Mapper;

namespace DinoPark.Service.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            // users
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<UsersServiceProfile>();
        });
    }
}
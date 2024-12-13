using DinoPark.DataAccess;
using DinoPark.Service.Settings;
using Microsoft.EntityFrameworkCore;

namespace DinoPark.Service.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, DinoParkSettings settings)
    {
        services.AddDbContextFactory<DinoParkDbContext>(options =>
            {
                options.UseNpgsql(settings.DinoParkDbConnectionString);
            }, 
            ServiceLifetime.Scoped);

    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DinoParkDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}
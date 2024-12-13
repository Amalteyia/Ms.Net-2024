namespace DinoPark.Service.Settings;

public class DinoParkSettingsReader
{
    public static DinoParkSettings Read(IConfiguration configuration)
    {
        return new DinoParkSettings()
        {
            DinoParkDbConnectionString = configuration.GetValue<string>("DinoParkDbContext")
        };
    }
}
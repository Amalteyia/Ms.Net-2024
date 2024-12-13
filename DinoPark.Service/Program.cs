using DinoPark.Service.IoC;
using DinoPark.Service.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = DinoParkSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

SerilogConfigurator.ConfigureService(builder);
DbContextConfigurator.ConfigureService(builder.Services, settings);
SwaggerConfigurator.ConfigureServices(builder.Services);
MapperConfigurator.ConfigureServices(builder.Services);
ServicesConfigurator.ConfigureServices(builder.Services, settings);
builder.Services.AddControllers();

var app = builder.Build();

SerilogConfigurator.ConfigureApplication(app);
DbContextConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);

app.MapControllers();

app.Run();

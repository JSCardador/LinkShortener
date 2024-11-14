using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Configurar Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
    return ConnectionMultiplexer.Connect(configuration);
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
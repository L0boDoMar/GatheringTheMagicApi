using GatheringTheMagic.Api.Extensions;
using GatheringTheMagic.Application.ExternalServices;
using GatheringTheMagic.Application.Services;
using GatheringTheMagic.Persistence;
using GatheringTheMagic.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IHttpClientService, HttpClientService>(client =>
{
    client.BaseAddress = new Uri("http://api.magicthegathering.io/v1/");
});

builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureCorsPolicy();
builder.Services.ConfigureTelemetry();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

CreateDatabase(app);


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.MapPrometheusScrapingEndpoint();

app.Run();

//Cria o banco e as tabelas definidas em AppDbContext
static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}
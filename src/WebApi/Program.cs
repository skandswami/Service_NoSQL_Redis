using FastEndpoints;
using FastEndpoints.Swagger;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

_ = builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_ = builder.Services.AddEndpointsApiExplorer();
_ = builder.Services.AddAuthentication();
_ = builder.Services.AddAuthorization();
_ = builder.Services.AddFastEndpoints();
_ = builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDoc(maxEndpointVersion: 1, tagIndex: 0, settings: x =>
{
    x.DocumentName = "Release 1.0";
    x.Title = "NoSQL Driver Service";
    x.Version = "1.0";
});
_ = builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis") ?? "localhost:5002";
    options.InstanceName = "Service_NoSql_";
});
_ = builder.Services.AddTransient<IDriverDataService, DriverDataService>();
var app = builder.Build();

_ = app.UseFastEndpoints();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseOpenApi();
    _ = app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
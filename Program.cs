using Voltix.SettingMicroservice.GrpcServices;
using Voltix.SettingMicroservice.Services;
using Voltix.Shared.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddRedisClient("voltix-setting-microservice-cache");

builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddControllers();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISettingsService, SettingService>();

var app = builder.Build();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGrpcService<SettingGrpcService>();

app.Run();

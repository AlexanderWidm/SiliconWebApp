using Infrastructure.Entities;
using Microsoft.OpenApi.Models;
using WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });


    options.CustomSchemaIds(type => type.FullName.Replace('.', '_'));

});

builder.Services.RegisterDbContexts(builder.Configuration);
builder.Services.RegisterRepositories(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
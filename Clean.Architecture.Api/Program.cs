using Clean.Architecture.Application;
using Clean.Architecture.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//TODO: Above Infrastructure reference is only for wire up Infrastructure dependency injection during app startup.
//Check this article from microsoft https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures

builder.Services.RegisterApplicationServices(builder.Configuration);
builder.Services.RegisterInfrastructureServices();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Uvod.Repository;
using Uvod.Repository.Common;
using Uvod.Service;
using Uvod.Service.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();



builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((container) =>
    {
        container.RegisterModule<ServiceDIModule>();
        container.RegisterModule<RepositoryDIModule>();
        
    }
    );
// Add services to the container.

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

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

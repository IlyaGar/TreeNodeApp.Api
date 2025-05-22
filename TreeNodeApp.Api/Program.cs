using Microsoft.EntityFrameworkCore;
using TreeNodeApp.Api.ExceptionHandling;
using TreeNodeApp.Api.WebApplicationBuilder;
using TreeNodeApp.DataAccess.Repository.Interface.Context;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TreeNodeDbContext>(options =>
    options.UseNpgsql(connectionString)
           .UseLazyLoadingProxies());


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DependencyConfig.ConfigureServices(builder.Services);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

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

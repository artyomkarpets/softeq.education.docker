using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using TrialsSystem.UserTasksService.Api.Filters;
using TrialsSystem.UserTasksService.Domain.AggregatesModel.UserTasksAggregate;
using TrialsSystem.UserTasksService.Infrastructure;
using TrialsSystem.UserTasksService.Infrastructure.Mapping;
using TrialsSystem.UserTasksService.Infrastructure.Repositories;
using TrialSystem.Shared.MongoConfigurations;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddFluentValidationAutoValidation();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo { Title = "TrialsSystem.UserTasksService", Version = "v1" }

            );
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
        builder.Services.AddScoped<UserTaskExceptionFilter>();
        builder.Services.AddAutoMapper(typeof(UserTaskMappingProfile).Assembly);
        builder.Services.AddHttpContextAccessor();

        ConfigureUserTasksDAL(builder);

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
    }


    private static void ConfigureUserTasksDAL(WebApplicationBuilder builder)
    {

        builder.Services.AddMongoCollection<UserTask>(
            builder.Configuration.GetConnectionString(ConnectionStrings.UserTasksDatabase),
            builder.Configuration.GetValue<string>("UsersTasksCollectionName"));

        builder.Services.AddScoped<IUserTaskRepository, UserTaskRepository>();


    }
}
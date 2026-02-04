using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Application.Data.Repositories;
using ToDo.Infrastructure.Data;
using ToDo.Infrastructure.Data.Repositories;

namespace ToDo.Infrastructure;

public static class ConfigureSevices
{
    public static IServiceCollection AddToDoDbContext(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        services.AddDbContext<ToDoDbContext> (options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("ToDoDbContext")
                );
        });

        return services;
    }

    public static IServiceCollection AddDataRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();

        return services;
    }
}

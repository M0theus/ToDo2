using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToDo.Domain.Contracts.Repositories;
using ToDo.Infra.Context;
using ToDo.Infra.Repository;
using Microsoft.AspNetCore.Builder;

namespace ToDo.Infra;

public static class DependencyInjection
{
    public static void AddInfraData(this IServiceCollection services, string connectionString)
    {
        var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

        services
            .AddDbContext<ApplicationDbContext>(dbContextOptions =>
            {
                dbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            });

        services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IAssignmentRepository, AssignmentRepository>()
            .AddScoped<IAssignmentListRepository, AssignmentListRepository>();
    }

    public static IApplicationBuilder UseMigrations(this IApplicationBuilder app, IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();

        return app;
    }
}
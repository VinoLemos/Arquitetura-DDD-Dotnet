using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }
}

public class DbTest : IDisposable
{
    private string databaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
    public ServiceProvider ServiceProvider { get; private set; }

    public DbTest()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<MyContext>(o =>
            o.UseMySql($"Persist Security Info=True;Server=127.0.0.1;Database={databaseName};User=root;Password=1234"),
            ServiceLifetime.Transient
        );
        
        ServiceProvider = serviceCollection.BuildServiceProvider();

        using var context = ServiceProvider.GetService<MyContext>();
        context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        using var context = ServiceProvider.GetService<MyContext>();
        context.Database.EnsureDeleted();
    }
}
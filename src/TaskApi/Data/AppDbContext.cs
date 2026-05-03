using Infrastructure.Messaging;
using Microsoft.EntityFrameworkCore;
using TaskApi.Models;
using Domain;

namespace TaskApi.Data;

public class AppDbContext : DbContext
{
    private readonly IDomainEventDispatcher _dispatcher;

    public  AppDbContext(DbContextOptions options, IDomainEventDispatcher dispatcher) 
        : base(options)
    {
        _dispatcher = dispatcher;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType? entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IHasDomainEvents).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Ignore(nameof(IHasDomainEvents.DomainEvents));
            }
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        List<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<IHasDomainEvents>>? domainEntities = ChangeTracker
            .Entries<IHasDomainEvents>()
            .Where(x => x.Entity.DomainEvents.Any())
            .ToList();

        List<DomainEvent>? domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        int result = await base.SaveChangesAsync(cancellationToken);

        await _dispatcher.DispatchAsync(domainEvents);

        foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<IHasDomainEvents>? entity in domainEntities)
        {
            entity.Entity.ClearDomainEvents();
        }

        return result;
    }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}

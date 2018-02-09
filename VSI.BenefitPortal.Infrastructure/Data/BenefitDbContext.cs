using Microsoft.EntityFrameworkCore;
using System.Linq;
using VSI.BenefitPortal.Core.Entities;
using VSI.BenefitPortal.Core.Interfaces;
using VSI.BenefitPortal.Core.SharedKennel;

namespace VSI.BenefitPortal.Infrastructure.Data
{
    public class BenefitDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public BenefitDbContext(DbContextOptions<BenefitDbContext> options, IDomainEventDispatcher dispatcher) : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Enrollee> Enrollees { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Dependent> Dependents { get; set; }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }

            return result;
        }
    }
}
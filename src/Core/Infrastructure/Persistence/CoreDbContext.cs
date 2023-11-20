using PastExamsHub.Base.Infrastructure.Persistence;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using PastExamsHub.Core.Domain.Entities;

namespace PastExamsHub.Core.Infrastructure.Persistence
{
    public class CoreDbContext : ApplicationDbContext, ICoreDbContext
    {

        public CoreDbContext
        (
            DbContextOptions<CoreDbContext> options,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService,
            IDateTime dateTime
        ) : base
        (
            options,
            currentUserService,
            domainEventService,
            dateTime
        )
        {
        }

        //TODO: needs better name
        public override bool OnMigrate()
        {
            return !Database.IsInMemory();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Asset>().HasData(AssetData);
        }
    }
}

using IdentityModel;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Infrastructure.Persistence;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace PastExamsHub.Core.Infrastructure.Persistence.Repositories
{
    public class UsersRepository :BaseRepository<ICoreDbContext, User>, IUsersRepository
    {

        public UsersRepository(ICoreDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await GetQuery().Where(x => x.Email == email).SingleOrDefaultAsync(cancellationToken);
        }
        public override IQueryable<User> GetQuery()
        {

            //double check
            return base.GetQuery();

        }
    }
}

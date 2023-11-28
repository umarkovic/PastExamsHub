using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Infrastructure.Persistence;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Infrastructure.Persistence.Repositories
{
    public class ExamRepository : BaseRepository<ICoreDbContext, Exam>, IExamRepository
    {

        public ExamRepository(ICoreDbContext dbContext) : base(dbContext)
        {
        }



        public override IQueryable<Exam> GetQuery()
        {

            //double check
            return base.GetQuery()
                .Include(x => x.Course)
                .Include(x=>x.Document)
                .Include(x=>x.Period);

        }
    }
}

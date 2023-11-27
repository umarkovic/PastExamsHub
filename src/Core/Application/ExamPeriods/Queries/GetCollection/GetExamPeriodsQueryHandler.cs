using MediatR;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Courses.Queries.GetCollection;
using PastExamsHub.Core.Application.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PastExamsHub.Core.Application.ExamPeriods.Queries.GetCollection
{
    public class GetExamPeriodsQueryHandler : IRequestHandler <GetExamPeriodsQuery,GetExamPeriodsQueryResult>
    {
        readonly ICoreDbContext DbContext;
        public GetExamPeriodsQueryHandler(ICoreDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<GetExamPeriodsQueryResult> Handle(GetExamPeriodsQuery request, CancellationToken cancellationToken)
        {
            var results = await (
                from ep in DbContext.ExamPeriods
                select new ExamPeriodModel
                {
                    Uid = ep.Uid,
                    Name = ep.Name,
                    StartDate = ep.StartDate.Date,
                    EndDate = ep.EndDate.Date,
                    PeriodDayDuration = (ep.EndDate.Date - ep.StartDate.Date).Days,
                }
                ).ToListAsync(cancellationToken);

            return new GetExamPeriodsQueryResult { Periods = results };
        }
    }
}

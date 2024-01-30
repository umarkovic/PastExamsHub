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
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Core.Application.Courses.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            var query  =  (
                from ep in DbContext.ExamPeriods
                orderby ep.StartDate descending
                select new ExamPeriodModel
                {
                    Uid = ep.Uid,
                    Name = ep.Name,
                    StartDate = ep.StartDate.Date,
                    EndDate = ep.EndDate.Date,
                    PeriodDayDuration = (ep.EndDate.Date - ep.StartDate.Date).Days,
                }
                );


            var results = await PaginationResult<ExamPeriodModel>.From(query, request.PageNumber, request.PageSize);

            return new GetExamPeriodsQueryResult 
            {
                Periods = results.Items,
                TotalCount = results.TotalCount,
                PageSize = results.PageSize,
                CurrentPage = results.CurrentPage,
                TotalPages = results.TotalPages,
                HasNext = results.HasNext,
                HasPrevious = results.HasPrevious
            };
        }
    }
}

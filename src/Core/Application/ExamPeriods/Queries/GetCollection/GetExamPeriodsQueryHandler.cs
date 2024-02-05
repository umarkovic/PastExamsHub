using MediatR;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Queries.GetCollection
{
    public class GetExamPeriodsQueryHandler : IRequestHandler <GetExamPeriodsQuery,GetExamPeriodsQueryResult>
    {
        readonly ICoreDbContext DbContext;
        readonly ISearchQueryBuilder<ExamPeriod> QueryBuilder;
        public GetExamPeriodsQueryHandler
        (
            ICoreDbContext dbContext,
            ISearchQueryBuilder<ExamPeriod> queryBuilder
        )
        {
            DbContext = dbContext;
            QueryBuilder = queryBuilder;
        }

        public async Task<GetExamPeriodsQueryResult> Handle(GetExamPeriodsQuery request, CancellationToken cancellationToken)
        {
            var query  =  (
                from ep in QueryBuilder.GetQuery(request.SearchText)
                orderby ep.StartDate descending
                where ep.IsSoftDeleted == false
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

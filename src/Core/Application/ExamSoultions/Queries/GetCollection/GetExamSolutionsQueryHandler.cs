using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.ExamPeriods;
using PastExamsHub.Core.Application.Exams.Models;
using PastExamsHub.Core.Application.Exams.Queries.GetSingle;
using PastExamsHub.Core.Application.ExamSoultions.Models;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Queries.GetCollection
{
    public class GetExamSolutionsQueryHandler : IRequestHandler<GetExamSolutionsQuery,GetExamSolutionsQueryResult>
    {


        readonly IExamsRepository ExamsRepository;
        readonly IBaseRepository<ExamSolution> ExamSolutionsRepository;
        readonly ICoreDbContext DbContext;
        public GetExamSolutionsQueryHandler
        (
            IExamsRepository examsRepository,
            IBaseRepository<ExamSolution> examSolutionsRepository,
            ICoreDbContext dbContext
        )
        {
            ExamsRepository = examsRepository;
            ExamSolutionsRepository = examSolutionsRepository;
            DbContext = dbContext;
        }


        public async Task<GetExamSolutionsQueryResult> Handle(GetExamSolutionsQuery request, CancellationToken cancellationToken)
        {

            var solutions =  await ( 
                from es in DbContext.ExamSolutions
                join e in DbContext.Exams on es.Exam.Id equals e.Id
                join c in DbContext.Courses on e.Course.Id equals c.Id
                join ep in DbContext.ExamPeriods on e.Period.Id equals ep.Id
                join u in DbContext.Users on es.User.Id equals u.Id
                where e.Uid == request.ExamUid
                select new ExamSolutionModel
                {
                    OwnerFirstName = u.FirstName,
                    OwnerLastName = u.LastName,
                    OwnerRole = u.Role,
                    OwnerStudyYear = u.StudyYear,
                    CourseName = c.Name,
                    Type = e.Type,
                    PeriodName = ep.Name,
                    PeriodType = ep.PeriodType,
                    Comment = es.Comment,
                    CreatedDateTimeUtc = es.CreatedDateTimeUtc,
                    GradeCount = es.GradeCount,
                    TaskNumber = es.TaskNumber,

                }).ToListAsync();

            //COMPLETE: Add grade calculation for exam soultions

            return new GetExamSolutionsQueryResult
            {
                Solutions = solutions
            };
        }
    }
}

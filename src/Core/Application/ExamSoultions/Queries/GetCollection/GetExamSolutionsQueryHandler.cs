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
                join f in DbContext.Files on es.File.Id equals f.Id
                join e in DbContext.Exams on es.Exam.Id equals e.Id
                join c in DbContext.Courses on e.Course.Id equals c.Id
                join ep in DbContext.ExamPeriods on e.Period.Id equals ep.Id
                join u in DbContext.Users on es.User.Id equals u.Id
                where e.Uid == request.ExamUid &&
                es.IsSoftDeleted == false
                select new ExamSolutionModel
                {
                    CreatedDateTimeUtc = es.CreatedDateTimeUtc,
                    OwnerFirstName = u.FirstName,
                    OwnerLastName = u.LastName,
                    OwnerRole = u.Role,
                    FileType = f.Type,
                    TaskNumber = es.TaskNumber,
                    GradeCount = es.GradeCount,
                    Grade = es.Grade,
                    OwnerStudyYear = u.StudyYear,
                    CourseName = c.Name,
                    Type = e.Type,
                    PeriodName = ep.Name,
                    PeriodType = ep.PeriodType,
                    SoulutionComment = es.Comment,

                }).ToListAsync();

            //COMPLETE: Add grade calculation for exam soultions in ExamSolutions
            //COMPLETE: add for each row, IsGradePosted by checking currentUserUid if exist in ExamSolutionGrade table

            return new GetExamSolutionsQueryResult
            {
                Solutions = solutions
            };
        }
    }
}

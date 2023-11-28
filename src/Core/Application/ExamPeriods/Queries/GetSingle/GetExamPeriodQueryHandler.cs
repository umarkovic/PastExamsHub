using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Courses;
using PastExamsHub.Core.Application.ExamPeriods.Queries.GetCollection;
using PastExamsHub.Core.Application.Exams.Models;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Queries.GetSingle
{
    public class GetExamPeriodQueryHandler : IRequestHandler<GetExamPeriodQuery,GetExamPeriodQueryResult>
    {

        readonly ICoreDbContext DbContext;
        readonly IBaseRepository<ExamPeriod> ExamPeriodRepository;
        public GetExamPeriodQueryHandler
        (
            ICoreDbContext dbContext,
            IBaseRepository<ExamPeriod> examPeriodRepository
        )
        {
            DbContext = dbContext;
            ExamPeriodRepository = examPeriodRepository;
        }

        public async Task<GetExamPeriodQueryResult> Handle(GetExamPeriodQuery request, CancellationToken cancellationToken)
        {
            var period = await ExamPeriodRepository.
                 GetQuery()
                 .Where(x => x.Uid == request.Uid)
                 .Select(c => new ExamPeriodModel
                 {
                     Uid = c.Uid,
                     Name = c.Name,
                     StartDate = c.StartDate.Date,
                     EndDate = c.EndDate.Date,
                     PeriodDayDuration = (c.EndDate.Date - c.StartDate.Date).Days,
                 })
                 .SingleOrDefaultAsync(cancellationToken);

            var exams = await (
                        from e in DbContext.Exams
                        join ep in DbContext.ExamPeriods on e.Period.Id equals ep.Id
                        join c in DbContext.Courses on e.Course.Id equals c.Id
                        join l in DbContext.Users on c.Lecturer.Id equals l.Id
                        where ep.Uid == period.Uid
                        select new ExamModel
                        {
                            CourseName = c.Name,
                            StudyYear = c.StudyYear,
                            CourseType = c.CourseType,
                            ESPB = c.ESPB,

                            LecturerFirstName = l.FirstName,
                            LecturerLastName = l.LastName,

                            ExamDate = e.ExamDate,
                            Notes = e.Notes,
                            NumberOfTasks = e.NumberOfTasks,
                            Type = e.Type,


                        }).ToListAsync(cancellationToken);

            return new GetExamPeriodQueryResult { ExamPeriod = period, Exams = exams };
        }
    }
}

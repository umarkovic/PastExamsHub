using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.ExamPeriods;
using PastExamsHub.Core.Application.Exams.Models;
using PastExamsHub.Core.Application.Exams.Queries.GetCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Queries.GetSingle
{
    public class GetExamQueryHandler : IRequestHandler<GetExamQuery,GetExamQueryResult>
    {
        readonly IExamsRepository ExamsRepository;
        readonly ICoreDbContext DbContext;
        public GetExamQueryHandler
        (
            IExamsRepository examsRepository,
            ICoreDbContext dbContext
        )
        {
            ExamsRepository = examsRepository;
            DbContext = dbContext;
        }


        public async Task<GetExamQueryResult> Handle(GetExamQuery request, CancellationToken cancellationToken)
        {

            var result = await ExamsRepository
                .GetQuery()
                .Where(x=>x.Uid==request.Uid)
                .Select(e => new ExamModel
                {
                    CourseUid = e.Course.Uid,
                    CourseName = e.Course.Name,
                    StudyYear = e.Course.StudyYear,
                    ESPB = e.Course.ESPB,
                    ExamDate = e.ExamDate,
                    CourseType = e.Course.CourseType,
                    LecturerFirstName = e.Course.Lecturer.FirstName,
                    LecturerLastName = e.Course.Lecturer.LastName,
                    Notes = e.Notes,
                    NumberOfTasks = e.NumberOfTasks,
                    Type = e.Type,
                    PeriodUid = e.Period.Uid,
                    ExamPeriod = ExamPeriodModel.From(e.Period)
                }).SingleOrDefaultAsync();



            //COMPLETE: Add exam soultions, comments

            return new GetExamQueryResult
            {
                Exam = result
            };
        }
    }
}

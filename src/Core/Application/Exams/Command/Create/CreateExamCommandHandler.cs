using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Command.Create
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand,CreateExamCommandResult>
    {
        readonly ICoreDbContext DbContext;
        readonly IBaseRepository<ExamPeriod> ExamPeriodRepository;
        readonly IBaseRepository<ExamPeriodExam> ExamPeriodExamRepository;
        readonly IExamRepository ExamRepository;
        readonly ICoursesRepository CoursesRepository;
        public CreateExamCommandHandler
        (
            IBaseRepository<ExamPeriod> examPeriodRepository,
            IBaseRepository<ExamPeriodExam> examPeriodExamRepository,
            IExamRepository examRepository,
            ICoursesRepository coursesRepository,
            ICoreDbContext dbContext

        )
        {
            ExamPeriodRepository = examPeriodRepository;
            ExamPeriodExamRepository = examPeriodExamRepository;
            ExamRepository = examRepository;
            CoursesRepository = coursesRepository;
            DbContext = dbContext;
        }
        public async Task<CreateExamCommandResult> Handle ( CreateExamCommand command, CancellationToken cancellationToken)
        {
            var course = await CoursesRepository.GetByUidAsync(command.CourseUid, cancellationToken);
            var examPeriod = await ExamPeriodRepository
                .GetQuery()
                .Include(x=>x.Exams)
                .Where(x=>x.Uid==command.PeriodUid)
                .SingleOrDefaultAsync();

            //COMPLETE: add document
            var exam = new Exam(course, examPeriod, null, command.Type, command.ExamDate, command.NumberOfTasks, command.Notes);
            ExamRepository.Insert(exam);

            var examPeriodExam  = new ExamPeriodExam(examPeriod, exam);
            examPeriod.Exams.Add(examPeriodExam);

            ExamPeriodRepository.Update(examPeriod);

           // ExamPeriodExamRepository.Insert(examPeriodExam);
            await DbContext.SaveChangesAsync(cancellationToken);


            return new CreateExamCommandResult { Uid = exam.Uid};
        }
    }
}

using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Exceptions;
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
        readonly IExamsRepository ExamRepository;
        readonly ICoursesRepository CoursesRepository;
        public CreateExamCommandHandler
        (
            IBaseRepository<ExamPeriod> examPeriodRepository,
            IBaseRepository<ExamPeriodExam> examPeriodExamRepository,
            IExamsRepository examRepository,
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

            var validationFailures = new List<ValidationFailure>();

            var examPeriod = await ExamPeriodRepository
                .GetQuery()
                .Include(x=>x.Exams)
                .ThenInclude(x=>x.Exam)
                .ThenInclude(x=>x.Course)
                .Where(x=>x.Uid==command.PeriodUid)
                .SingleOrDefaultAsync();


            var existingExxamCourseName = await(
                from ep in DbContext.ExamPeriods
                join e in DbContext.Exams on ep.Id equals e.Period.Id
                join c in DbContext.Courses on e.Course.Id equals c.Id
                where ep.Uid == command.PeriodUid && c.Uid == command.CourseUid
                select c.Name
                        ).SingleOrDefaultAsync(cancellationToken);


            #region Validations

            if (!string.IsNullOrEmpty(existingExxamCourseName))
            {
                validationFailures.Add(new ValidationFailure("Uid", "Exam with course: " + existingExxamCourseName + " already exist in "+examPeriod.Name +" period." ));
            }

            if (command.ExamDate <= examPeriod.StartDate)
            {
                validationFailures.Add(new ValidationFailure("ExamDate", "Exam date must be greather than period start date : " + examPeriod.StartDate+"."));
            }

            if (command.ExamDate >= examPeriod.EndDate)
            {
                validationFailures.Add(new ValidationFailure("ExamDate", "Exam date must be less than period end date : " + examPeriod.EndDate+".")); ;
            }


            if (validationFailures.Any())
            {
                var validationResult = new ValidationResult(validationFailures);
                throw new ValidationException(validationResult.Errors);
            }
            #endregion Validations

            var course = await CoursesRepository.GetByUidAsync(command.CourseUid, cancellationToken);
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

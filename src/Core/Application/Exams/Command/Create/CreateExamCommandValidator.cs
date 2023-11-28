using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Command.Create
{
    public class CreateExamCommandValidator : AbstractValidator<CreateExamCommand>
    {
        readonly IBaseRepository<ExamPeriod> ExamPeriodRepository;
        public CreateExamCommandValidator
       (
            IBaseRepository<ExamPeriod> examPeriodRepository
       )
    {
            ExamPeriodRepository = examPeriodRepository;



            //COMPLETE: add validation if Exam is already created for givvn period

            RuleFor(x => x.ExamDate)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty()
                  .MustAsync(async (context, date, cancellation) =>
                  {
                      var period =await ExamPeriodRepository
                      .GetQuery()
                      .Where(x=>x.Uid == context.PeriodUid)
                      .SingleOrDefaultAsync();

                      return date >= period.StartDate;

                  })
               .WithMessage("Exam date must be greather than exam period start date.");


            RuleFor(x => x.ExamDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                 .MustAsync(async (context, date, cancellation) =>
                 {
                     var period = await ExamPeriodRepository
                     .GetQuery()
                     .Where(x => x.Uid == context.PeriodUid)
                     .SingleOrDefaultAsync();

                     return date <= period.EndDate;

                 })
              .WithMessage("Exam date must be Less than exam period end date.");
        }
}
}

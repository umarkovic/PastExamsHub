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


            RuleFor(x => x.ExamDate)
                .Cascade(CascadeMode.Stop)
                 .NotNull()
                 .NotEmpty();

            RuleFor(x => x.PeriodUid)
               .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.CourseUid)
               .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.NumberOfTasks)
               .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();


        }
    }
}

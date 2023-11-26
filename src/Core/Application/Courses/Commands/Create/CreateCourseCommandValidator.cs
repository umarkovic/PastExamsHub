using FluentValidation;
using PastExamsHub.Core.Application.Users.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Commands.Create
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.StudyYear)
                .NotEmpty();

            RuleFor(x => x.LecturerUid)
                .NotNull()
                .NotEmpty();
        }
    }
}

using MediatR;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Commands.Create
{
    public class CreateCourseCommand : IRequest<CreateCourseCommandResult>
    {
        public string LecturerUid { get; set; }
        public string Name { get; set; }
        public CourseType CourseType { get; set; }
        public int StudyYear { get; set; }
        public int ESPB { get; set; }
    }
}

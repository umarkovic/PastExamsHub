using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Commands.Delete
{
    public class DeleteCourseCommand : IRequest<DeleteCourseCommandResult>
    {
        public string Uid { get; set; }
    }
}

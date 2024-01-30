using MediatR;
using PastExamsHub.Base.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Queries.GetCollection
{
    public class GetCoursesQuery : PaginationSpecification, IRequest<GetCoursesQueryResult>
    {
        public int? StudyYear { get; set; }
    }
}

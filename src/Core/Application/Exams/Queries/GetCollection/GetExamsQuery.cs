using MediatR;
using PastExamsHub.Base.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Queries.GetCollection
{
    public class GetExamsQuery : PaginationSpecification, IRequest<GetExamsQueryResult>
    {
        public string ExamPeriodUid { get; set; }
        public string CourseUid { get; set; }
    }
}

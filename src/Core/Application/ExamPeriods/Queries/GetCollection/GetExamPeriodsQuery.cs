using MediatR;
using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Core.Application.Courses.Queries.GetCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Queries.GetCollection
{
    public class GetExamPeriodsQuery : IRequest<GetExamPeriodsQueryResult>
    {
        [OpenApiExclude]
        public string Uid { get; set; }
    }
}

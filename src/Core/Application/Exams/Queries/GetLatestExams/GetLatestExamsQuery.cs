using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Queries.GetLatestExams
{
    public class GetLatestExamsQuery : IRequest<GetLatestExamsQueryResult>
    {
    }
}

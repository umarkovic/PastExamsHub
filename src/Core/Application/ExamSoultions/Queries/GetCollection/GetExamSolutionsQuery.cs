using MediatR;
using PastExamsHub.Base.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Queries.GetCollection
{
    public class GetExamSolutionsQuery : PaginationSpecification, IRequest<GetExamSolutionsQueryResult>
    {
        public string ExamUid { get; set; }
    }
}

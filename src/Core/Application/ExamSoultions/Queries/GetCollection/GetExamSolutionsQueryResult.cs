using PastExamsHub.Core.Application.ExamSoultions.Models;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Queries.GetCollection
{
    public class GetExamSolutionsQueryResult
    {
        public List<ExamSolutionModel> Solutions { get; set; }
    }
}

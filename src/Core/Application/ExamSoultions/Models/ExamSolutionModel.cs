using PastExamsHub.Base.Domain.Enums;
using PastExamsHub.Core.Application.ExamPeriods;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Models
{
    public class ExamSolutionModel
    {

        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public int? OwnerStudyYear { get; set; }
        public RoleType OwnerRole { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public int? TaskNumber { get; set; }

        //public Document Document { get; set; }
        public int GradeCount { get; set; }
        public string CourseName { get; set; }
        public ExamType Type { get; set; }
        public string PeriodName { get; set; }
        public ExamPeriodType PeriodType { get; set; }



    }
}

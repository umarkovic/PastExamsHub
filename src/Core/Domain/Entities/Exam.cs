using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Domain.Entities
{
    public class Exam : DomainEntity
    {
        public Course Course { get; set; }
        public ExamPeriod Period { get; set; }
        public Document Document { get; set; }
        public ExamType Type { get; set; }
        public DateTime ExamDate { get; set; }
        public int NumberOfTasks { get; set; }
        public string Notes { get; set; }

    }
}

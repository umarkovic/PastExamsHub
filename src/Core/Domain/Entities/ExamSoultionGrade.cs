using PastExamsHub.Base.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Domain.Entities
{
    public class ExamSoultionGrade : DomainEntity
    {
        public User User { get; set; }
        public ExamSolution Solution { get; set; }
        public int Grade { get; set; } //Can be -1 or +1
    }
}

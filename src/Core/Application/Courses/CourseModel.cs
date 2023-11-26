using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses
{
    public class CourseModel
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public CourseType CourseType { get; set; }
        public string LecturerFirstName { get; set; }
        public string LecturerLastName { get; set; }
        public int StudyYear { get; set; }
        public int ESPB { get; set; }
    }
}

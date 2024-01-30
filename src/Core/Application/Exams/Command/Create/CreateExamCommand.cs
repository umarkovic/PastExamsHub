﻿using MediatR;
using PastExamsHub.Core.Domain.Entities;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Command.Create
{
    public class CreateExamCommand : IRequest<CreateExamCommandResult>
    {

        public string CourseUid { get; set; }
        public string PeriodUid { get; set; }
        public string DocumentPath { get; set; }
        public ExamType Type { get; set; }
        public DateTime ExamDate { get; set; }
        public int NumberOfTasks { get; set; }
        public string Notes { get; set; }
    }
}
﻿using MediatR;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Command.Create
{
    public class CreateExamPeriodCommand : ExamPeriodCommand, IRequest<CreateExamPeriodCommandResult>
    {
      
    }
}

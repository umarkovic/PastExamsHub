﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Commands.Create
{
    public class CreateExamSolutionCommand : IRequest<CreateExamSolutionCommandResult>
    {
        public string UserUid { get; set; }
        public string ExamUid { get; set; }
        public string Comment { get; set; }
        public int? TaskNumber { get; set; }

        //public byte[] Document { get; set; }

    }
}
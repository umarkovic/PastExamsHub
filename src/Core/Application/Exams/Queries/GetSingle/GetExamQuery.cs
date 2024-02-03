﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Queries.GetSingle
{
    public class GetExamQuery : IRequest<GetExamQueryResult>
    {
        public string Uid { get; set; }
    }
}
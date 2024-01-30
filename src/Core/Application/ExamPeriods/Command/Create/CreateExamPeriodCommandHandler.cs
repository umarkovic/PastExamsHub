﻿using MediatR;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Command.Create
{
    public class CreateExamPeriodCommandHandler : IRequestHandler<CreateExamPeriodCommand, CreateExamPeriodCommandResult>
    {
        readonly ICoreDbContext DbContext;
        readonly IBaseRepository<ExamPeriod> ExamPeriodRepository;
        public CreateExamPeriodCommandHandler
        (
            IBaseRepository<ExamPeriod> examPeriodRepository,
            ICoreDbContext dbContext

        )
        {
            ExamPeriodRepository = examPeriodRepository;
            DbContext = dbContext;
        }
        public async Task<CreateExamPeriodCommandResult> Handle(CreateExamPeriodCommand command, CancellationToken cancellationToken)
        {
            var period = new ExamPeriod(command.Name, command.StartDate, command.EndDate, command.PeriodType);

            ExamPeriodRepository.Insert(period);

            await DbContext.SaveChangesAsync(cancellationToken);
            return new CreateExamPeriodCommandResult { };
        }
    }
}
using MediatR;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Command.Create
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand,CreateExamCommandResult>
    {
        readonly ICoreDbContext DbContext;
        readonly IBaseRepository<PastExamsHub.Core.Domain.Entities.ExamPeriod> ExamPeriodRepository;
        public CreateExamCommandHandler
        (
            IBaseRepository<PastExamsHub.Core.Domain.Entities.ExamPeriod> examPeriodRepository

        )
        {
            ExamPeriodRepository = examPeriodRepository;
        }
        public async Task<CreateExamCommandResult> Handle ( CreateExamCommand command, CancellationToken cancellationToken)
        {


            return new CreateExamCommandResult { };
        }
    }
}

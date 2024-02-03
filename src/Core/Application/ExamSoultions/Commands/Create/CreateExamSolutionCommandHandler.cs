using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Exams.Command.Create;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Commands.Create
{
    public class CreateExamSolutionCommandHandler : IRequestHandler<CreateExamSolutionCommand, CreateExamSolutionCommandResult>
    {

        readonly ICoreDbContext DbContext;
        readonly IUsersRepository UsersRepository;
        readonly IExamsRepository ExamRepository;
        readonly IBaseRepository<ExamSolution> ExamSolutionRepository;
        public CreateExamSolutionCommandHandler
        (
            IUsersRepository usersRepository,
            IExamsRepository examRepository,
            ICoreDbContext dbContext,
            IBaseRepository<ExamSolution> examSolutionRepository

        )
        {

            UsersRepository= usersRepository;
            ExamRepository = examRepository;
            DbContext = dbContext;
            ExamSolutionRepository = examSolutionRepository;
        }

        public async Task<CreateExamSolutionCommandResult> Handle(CreateExamSolutionCommand command, CancellationToken cancellationToken)
        {

            var exam = await ExamRepository.GetQuery().Where(x => x.Uid == command.ExamUid).SingleOrDefaultAsync();
            var user = await UsersRepository.GetByUidAsync(command.UserUid,cancellationToken);

            var examSoultion = new ExamSolution
            {

                Uid = Guid.NewGuid().ToString(),
                Exam = exam,
                User = user,
                GradeCount = 0,
                TaskNumber = command.TaskNumber,
                PeriodType = exam.Period.PeriodType,
                Comment = command.Comment
            };

            ExamSolutionRepository.Insert(examSoultion);
            await DbContext.SaveChangesAsync(cancellationToken);


      

            return new CreateExamSolutionCommandResult { Uid = null };
        }
    }
}


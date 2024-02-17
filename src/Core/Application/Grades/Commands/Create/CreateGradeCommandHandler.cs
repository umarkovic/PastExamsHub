using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Grades.Commands.Create
{
    public class CreateGradeCommandHandler : IRequestHandler<CreateGradeCommand, CreateGradeCommandResult>
    {
        readonly IUsersRepository UsersRepository;
        readonly IBaseRepository<ExamSolution> ExamSolutionsRepository;
        readonly IBaseRepository<ExamSolutionGrade> GradesRepository;
        readonly ICoreDbContext DbContext;

        public CreateGradeCommandHandler
        (
            IUsersRepository usersRepository,
            IBaseRepository<ExamSolution> examSolutionsRepository,
            IBaseRepository<ExamSolutionGrade> gradesRepository,
            ICoreDbContext dbContext

        )
        {
            ExamSolutionsRepository = examSolutionsRepository;
            UsersRepository= usersRepository;
            GradesRepository = gradesRepository;
            DbContext = dbContext;
        }



        public async Task<CreateGradeCommandResult> Handle ( CreateGradeCommand command, CancellationToken cancellationToken)
        {
            int grade = command.IsPositive ? 1 : -1;

            var solution = await ExamSolutionsRepository.GetQuery().Where(x => x.Uid == command.ExamSolutionUid).SingleOrDefaultAsync();
            var user = await UsersRepository.GetByUidAsync(command.UserUid, cancellationToken);

            solution.GradeCount++;
            solution.Grade = 0; // Calculate


            var calculatedGrade = GradesRepository.GetQuery().Where(x => x.Solution == solution).Sum(x => x.Grade);
            calculatedGrade = calculatedGrade + grade;

            ExamSolutionsRepository.Update(solution);
            
            var newGrade = new ExamSolutionGrade(user, solution, grade);
            GradesRepository.Insert(newGrade);



            return new CreateGradeCommandResult { Grade = 1, Uid = null };
        }
    }
}

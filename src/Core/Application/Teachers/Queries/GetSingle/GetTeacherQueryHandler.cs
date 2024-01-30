﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Users.Models;
using PastExamsHub.Core.Application.Courses.Models;
using PastExamsHub.Core.Application.Teachers.Models;
using PastExamsHub.Core.Application.Users.Commands.Update;
using PastExamsHub.Core.Application.Users.Queries.GetSingle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Teachers.Queries.GetSingle
{
    public class GetTeacherQueryHandler : IRequestHandler<GetTeacherQuery, GetTeacherQueryResult>
    {
        private readonly IUsersRepository UsersRepository;
        public ICoreDbContext DbContext;
        public GetTeacherQueryHandler
        (
            IUsersRepository usersRepository,
            ICoreDbContext dbContext
        )
        {
            UsersRepository = usersRepository;
            DbContext = dbContext;
        }


        public async Task<GetTeacherQueryResult> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacher = await UsersRepository
                .GetQuery()
                .Where(x => x.Uid == request.Uid)
                .Select(TeacherModel.Projection)
                .FirstOrDefaultAsync(cancellationToken);

            var courses = await 
                (
                 from c in DbContext.Courses
                 join u in DbContext.Users on c.Lecturer.Id equals u.Id
                 where u.Uid == request.Uid
                 select new CourseListModel
                 {
                     Name = c.Name,
                     Uid = c.Uid
                 }
                ).ToListAsync();

            teacher.Courses = courses;


            return new GetTeacherQueryResult { User = teacher };
        }
    }
}

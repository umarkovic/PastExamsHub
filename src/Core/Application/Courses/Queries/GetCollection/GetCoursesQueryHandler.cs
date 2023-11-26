using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Users.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Queries.GetCollection
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery,GetCoursesQueryResult>
    {

        readonly ICoreDbContext DbContext;
        public GetCoursesQueryHandler(ICoreDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<GetCoursesQueryResult> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var results = await (
                from c in DbContext.Courses
                join u in DbContext.Users on c.Lecturer.Id equals u.Id
                select new CourseModel
                {
                    Uid = c.Uid,
                    Name = c.Name,
                    StudyYear =c.StudyYear,
                    ESPB = c.ESPB,
                    LecturerFirstName = u.FirstName,
                    LecturerLastName = u.LastName,
                    CourseType = c.CourseType
                }
                ).ToListAsync(cancellationToken);

            return new GetCoursesQueryResult { Courses = results };
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Models;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Users.Models;
using PastExamsHub.Core.Application.Courses.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Queries.GetCollection
{
    public class GetCoursesQueryHandler :  IRequestHandler<GetCoursesQuery,GetCoursesQueryResult>
    {

        readonly ICoreDbContext DbContext;
        public GetCoursesQueryHandler(ICoreDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<GetCoursesQueryResult> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            //COMPLETE: Add fulltext search

            var query = (
                from c in DbContext.Courses
                join u in DbContext.Users on c.Lecturer.Id equals u.Id into u_join
                from _u in u_join.DefaultIfEmpty()
                where (request.StudyYear== null|| c.StudyYear == request.StudyYear)
                select new CourseModel
                {
                    Uid = c.Uid,
                    Name = c.Name,
                    StudyYear =c.StudyYear,
                    ESPB = c.ESPB,
                    LecturerFirstName = _u != null ? _u.FirstName : "/",
                    LecturerLastName = _u != null ? _u.LastName : "/",
                    CourseType = c.CourseType
                }
                );


            var results = await PaginationResult<CourseModel>.From(query, request.PageNumber, request.PageSize);


            return new GetCoursesQueryResult 
            { 
                Courses = results.Items,
                TotalCount = results.TotalCount,
                PageSize = results.PageSize,
                CurrentPage = results.CurrentPage,
                TotalPages = results.TotalPages,
                HasNext = results.HasNext,
                HasPrevious = results.HasPrevious
            };
        }
    }
}

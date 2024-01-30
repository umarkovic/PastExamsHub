using MediatR;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Controllers;
using PastExamsHub.Core.Application.Courses.Commands.Create;
using PastExamsHub.Core.Application.Courses.Commands.Update;
using PastExamsHub.Core.Application.Courses.Queries.GetCollection;
using PastExamsHub.Core.Application.Courses.Queries.GetSingle;
using PastExamsHub.Core.Application.Users.Commands.Update;
using System.Net;
using System.Threading.Tasks;

namespace PastExamsHub.Core.WebAPI.Controllers
{
    public class CoursesController : ApiController
    {
        public CoursesController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
            : base(mediator, currentUserService)
        {

        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetCoursesQueryResult>> GetCollection([FromQuery] GetCoursesQuery request)
        {

            var result = await Mediator.Send(request);

            return Ok(result);
        }


        [HttpGet("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetCourseQueryResult>> GetSingle(string uid, [FromQuery] GetCourseQuery request)
        {
            request.Uid = WebUtility.UrlDecode(uid);
            var result = await Mediator.Send(request);

            return Ok(result);
        }


        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Create(CreateCourseCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult<UpdateCourseCommandResult>> Update(string uid, UpdateCourseCommand command)
        {

            command.Uid = WebUtility.UrlDecode(uid);
            var result = await Mediator.Send(command);

            return Ok(result);
        }


    }
}

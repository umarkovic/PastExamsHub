using MediatR;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Controllers;
using PastExamsHub.Core.Application.Teachers.Queries.GetCollection;
using PastExamsHub.Core.Application.Teachers.Queries.GetSingle;
using System.Net;
using System.Threading.Tasks;

namespace PastExamsHub.Core.WebAPI.Controllers
{
    public class TeachersController : ApiController
    {
        public TeachersController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
            : base(mediator, currentUserService)
        {

        }

        [HttpGet("Teachers")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetTeachersQueryResult>> GetCollection([FromQuery] GetTeachersQuery request)
        {

            var result = await Mediator.Send(request);

            return Ok(result);
        }


        [HttpGet("{uid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetTeacherQueryResult>> GetSingle(string uid, [FromQuery] GetTeacherQuery request)
        {
            request.Uid = WebUtility.UrlDecode(uid);
            var result = await Mediator.Send(request);

            return Ok(result);
        }

        //[HttpPut("{uid}")]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        //public async Task<ActionResult<UpdateUserCommandResult>> Update(string uid, UpdateUserCommand command)
        //{

        //    command.UserUid = WebUtility.UrlDecode(uid);
        //    var result = await Mediator.Send(command);

        //    return Ok(result);
        //}



    }
}

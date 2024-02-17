using MediatR;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Controllers;
using PastExamsHub.Core.Application.Exams.Command.Create;
using PastExamsHub.Core.Application.Exams.Queries.GetCollection;
using PastExamsHub.Core.Application.ExamSoultions.Commands.Create;
using PastExamsHub.Core.Application.ExamSoultions.Queries.GetCollection;
using System.Threading.Tasks;

namespace PastExamsHub.Core.WebAPI.Controllers
{
    public class ExamSolutionController : ApiController
    {
        public ExamSolutionController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
            : base(mediator, currentUserService)
        {

        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetExamSolutionsQueryResult>> GetCollection([FromQuery] GetExamSolutionsQuery request)
        {

            var result = await Mediator.Send(request);

            return Ok(result);
        }



        [HttpPost("upload")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<ActionResult<CreateExamSolutionCommandResult>> Create([FromQuery] CreateExamSolutionCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}

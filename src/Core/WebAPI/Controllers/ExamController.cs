using MediatR;
using Microsoft.AspNetCore.Mvc;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.WebAPI.Controllers;
using PastExamsHub.Core.Application.ExamPeriods.Command.Create;
using PastExamsHub.Core.Application.ExamPeriods.Command.Delete;
using PastExamsHub.Core.Application.ExamPeriods.Command.Update;
using PastExamsHub.Core.Application.ExamPeriods.Queries.GetCollection;
using PastExamsHub.Core.Application.ExamPeriods.Queries.GetSingle;
using PastExamsHub.Core.Application.Exams.Command.Create;
using System.Net;
using System.Threading.Tasks;

namespace PastExamsHub.Core.WebAPI.Controllers
{
    public class ExamController : ApiController
    {
        public ExamController
        (
            IMediator mediator,
            ICurrentUserService currentUserService
        )
            : base(mediator, currentUserService)
        {

        }

        //[HttpGet("ExamPeriod")]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        //public async Task<ActionResult<GetExamPeriodsQueryResult>> GetCollection([FromQuery] GetExamPeriodsQuery request)
        //{

        //    var result = await Mediator.Send(request);

        //    return Ok(result);
        //}



        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<CreateExamCommandResult>> Create(CreateExamCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        //[HttpGet("{uid}")]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        //public async Task<ActionResult<GetExamPeriodQueryResult>> GetSingle(string uid, [FromQuery] GetExamPeriodQuery request)
        //{
        //    request.Uid = WebUtility.UrlDecode(uid);
        //    var result = await Mediator.Send(request);

        //    return Ok(result);
        //}

        //[HttpPut("{uid}")]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        //public async Task<ActionResult<UpdateExamPeriodCommandResult>> Update(string uid, UpdateExamPeriodCommand command)
        //{

        //    command.Uid = WebUtility.UrlDecode(uid);
        //    var result = await Mediator.Send(command);

        //    return Ok(result);
        //}


        //[HttpDelete("{uid}")]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        //public async Task<ActionResult<DeleteExamPeriodCommandResult>> Delete(string uid, DeleteExamPeriodCommand command)
        //{
        //    command.Uid = WebUtility.UrlDecode(uid);

        //    var result = await Mediator.Send(command);

        //    return Ok(result);
        //}
    }
}


using MediatR;
using PastExamsHub.Base.Application.Common.Models;

namespace PastExamsHub.Core.Application.Teachers.Queries.GetCollection
{
    public class GetTeachersQuery : PaginationSpecification, IRequest<GetTeachersQueryResult>
    {
    }
}

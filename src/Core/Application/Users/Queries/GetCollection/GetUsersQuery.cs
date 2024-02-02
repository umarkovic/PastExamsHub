using MediatR;
using PastExamsHub.Base.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Common.Users.Queries.GetCollection
{
    public class GetUsersQuery : PaginationSpecification, IRequest<GetUsersQueryResult>
    {
    }
}

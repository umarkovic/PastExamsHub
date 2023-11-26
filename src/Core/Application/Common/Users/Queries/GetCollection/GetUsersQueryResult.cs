using PastExamsHub.Core.Application.Common.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Common.Users.Queries.GetCollection
{
    public class GetUsersQueryResult
    {
        public List<UserModel> Users { get; set; }
    }
}

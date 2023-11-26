﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IronOcr;
using System.Net.NetworkInformation;

namespace PastExamsHub.Core.Application.Common.Users.Queries.GetCollection
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersQueryResult>
    {
        readonly ICoreDbContext DbContext;
        public GetUsersQueryHandler(ICoreDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<GetUsersQueryResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {

            


            var results = await (
                from u in DbContext.Users
                select new UserModel
                {
                    Uid = u.Uid,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    StudyYear = u.StudyYear,
                    Gender = u.Gender,
                    Index = u.Index,
                    Role = u.Role,
                }
                ).ToListAsync(cancellationToken);

            return new GetUsersQueryResult { Users = results};
        }

        static string GetFileExtension(string filePath)
        {
            // Get the last portion after the last dot in the string
            int lastIndex = filePath.LastIndexOf('.');
            if (lastIndex >= 0)
            {
                string extension = filePath.Substring(lastIndex + 1);
                return extension;
            }
            return ""; // If no extension found
        }
    }
}

using MediatR;
using Microsoft.Extensions.Configuration;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Users.Commands.SignIn
{
    public class SignInCommandHandler : INotificationHandler<SignInCommand> //REVIEW: Handler name MUST start with Command name; SignInCoachCommandHandler -> SignInCommandCoachHandler
    {
        readonly IMediator Mediator;//REVIEW: not used - remove
        readonly IUsersRepository UsersRepository;
        readonly ICurrentUserService CurrentUserService;
        readonly ICoreDbContext DbContext;
        public SignInCommandHandler
        (
            IMediator mediator,

            IUsersRepository usersRepository,
            ICurrentUserService currentUserService,
            ICoreDbContext dbContext,
            IConfiguration configuration
        )
        {
            Mediator = mediator;
            CurrentUserService = currentUserService;
            UsersRepository = usersRepository;
            DbContext = dbContext;



        }


        public async Task Handle(SignInCommand command, CancellationToken cancellationToken)
        {
            //Handler for users login 
            var currentUser = CurrentUserService;
            var user = await UsersRepository.GetByEmailAsync(command.Email, cancellationToken);

            if(user == null)
            {
                //COMPLETE: Finisih after introducing CurrentUserService working
            }

        }

    }
}

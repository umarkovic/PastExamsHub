using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Services;
using FluentValidation.Results;
using PastExamsHub.Authority.Application.Common.Interfaces;
using PastExamsHub.Base.Application.Common.Exceptions;
using PastExamsHub.Base.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using PastExamsHub.Authority.Infrastructure.Identity;
using PastExamsHub.Base.Domain.Common;

namespace PastExamsHub.Authority.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        readonly UserManager<IdentityApplicationUser> UserManager;
        readonly SignInManager<IdentityApplicationUser> SignInManager;
        readonly IIdentityServerInteractionService Interaction;

        public IdentityService
        (
            UserManager<IdentityApplicationUser> userManager,
            SignInManager<IdentityApplicationUser> signInManager,
            IIdentityServerInteractionService interaction
        )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Interaction = interaction;
        }

        async Task<IdentityApplicationUser> _FindByIdAsync(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), userId);
            }

            return user;
        }

        async Task<IdentityApplicationUser> _FindByEmailAsync(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new NotFoundException(nameof(IdentityApplicationUser), email);
            }

            return user;
        }

        public async Task<IApplicationUser> FindByEmailAsync(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new NotFoundException(nameof(IdentityApplicationUser), email);
            }

            return user;
        }

        public async Task SignInAsync(string email, string password, string returnUri)
        {
            string returnUrl = new Uri(returnUri).PathAndQuery;
            var context = await Interaction.GetAuthorizationContextAsync(returnUrl);
            if (context == null)
            {
                var validationFailure = new ValidationFailure(nameof(returnUrl), "Not authorized");
                throw new Base.Application.Common.Exceptions.ValidationException(validationFailure);
            }

            var result = await SignInManager.PasswordSignInAsync(email, password, true, false);
            result.ThrowOnFailure();
        }

        public async Task<string> SignOutAsync(string logoutId)
        {
            var context = await Interaction.GetLogoutContextAsync(logoutId);

            await SignInManager.SignOutAsync();

            return context?.PostLogoutRedirectUri;
        }

        public async Task ResetPasswordAsync(string email, string token, string password)
        {
            var user = await _FindByEmailAsync(email);

            var result = await UserManager.ResetPasswordAsync(user, token, password);
            result.ThrowOnFailure();
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _FindByEmailAsync(email);

            return await UserManager.GeneratePasswordResetTokenAsync(user);
        }
    }
}

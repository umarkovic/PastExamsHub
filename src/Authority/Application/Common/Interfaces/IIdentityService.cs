using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Domain.Common;

namespace PastExamsHub.Authority.Application.Common.Interfaces
{
    public interface IIdentityService 
    {
        Task<IApplicationUser> FindByEmailAsync(string email);
        Task SignInAsync(string email, string password, string returnUri);
        Task<string> SignOutAsync(string logoutId);
        Task<string> GeneratePasswordResetTokenAsync(string email);
        Task ResetPasswordAsync(string email, string token, string password);
    }
}

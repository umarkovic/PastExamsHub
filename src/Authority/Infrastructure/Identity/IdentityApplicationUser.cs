using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Base.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace PastExamsHub.Authority.Infrastructure.Identity
{
    //IMPORTANT: only for persistence
    public class IdentityApplicationUser : IdentityUser, IApplicationUser
    {


        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; } 

        public RoleType Role { get; set; }

        public UserStatusType Status { get; set; } //TODO: keep?

        public DateTime LastActivityDateTimeUtc { get; set; }
		
		public DateTime CreatedDateTimeUtc { get; set; }
		
        public string CreatedByUserUid { get; set; }
		
        public DateTime? LastModifiedDateTimeUtc { get; set; }
		
        public string LastModifiedByUserUid { get; set; }
		
        public DateTime? DeletedDateTimeUtc { get; set; }
		
        public string DeletedByUserUid { get; set; }

        public static IdentityApplicationUser From(IApplicationUser applicationUser)
        {
            var user = new IdentityApplicationUser()
            {
                EmailConfirmed = true
            };
            user.UpdateFrom(applicationUser);
            return user;
        }

        internal void UpdateFrom(IApplicationUser applicationUser)
        {
            UserName = applicationUser.Email;
            Email = applicationUser.Email;
            PhoneNumber = applicationUser.PhoneNumber;
            FirstName = applicationUser.FirstName;
            LastName = applicationUser.LastName;
            Role = applicationUser.Role;
            Status = applicationUser.Status;
            LastActivityDateTimeUtc = applicationUser.LastActivityDateTimeUtc;
            LastModifiedByUserUid = applicationUser.LastModifiedByUserUid;
            LastModifiedDateTimeUtc = applicationUser.LastModifiedDateTimeUtc;
            CreatedByUserUid = applicationUser.CreatedByUserUid;
            CreatedDateTimeUtc = applicationUser.CreatedDateTimeUtc;
            DeletedByUserUid = applicationUser.DeletedByUserUid;
            DeletedDateTimeUtc = applicationUser.DeletedDateTimeUtc;
            


        }
    }
}

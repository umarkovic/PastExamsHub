using System;
using System.Collections.Generic;
using System.Text;
using PastExamsHub.Base.Domain.Enums;

namespace PastExamsHub.Base.Domain.Common
{
    //IMPORTANT: application-wide usage
    public class ApplicationUser : IApplicationUser
    {
     
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }      
        public RoleType Role { get; set; }//TODO: roles (m:n)
        public UserStatusType Status { get; set; }
        public DateTime LastActivityDateTimeUtc { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public string CreatedByUserUid { get; set; }
        public DateTime? LastModifiedDateTimeUtc { get; set; }
        public string LastModifiedByUserUid { get; set; }
        public DateTime? DeletedDateTimeUtc { get; set; }
        public string DeletedByUserUid { get; set; }

        public static ApplicationUser From(IApplicationUser applicationUser)
        {
            return new ApplicationUser()
            {
                
                Email = applicationUser.Email,
                PhoneNumber = applicationUser.PhoneNumber,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Role = applicationUser.Role,
                Status = applicationUser.Status,
                LastActivityDateTimeUtc = applicationUser.LastActivityDateTimeUtc
            };
        }
    }
}

using PastExamsHub.Base.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastExamsHub.Base.Domain.Common
{
    // for reasoning & what seems as complicated alternative see:
    // https://timschreiber.com/2015/01/14/persistence-ignorant-asp-net-identity-with-patterns-part-1/
    public interface IApplicationUser : IAuditableEntity
    {
  
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleType Role { get; set; }
        public UserStatusType Status { get; set; }
        public DateTime LastActivityDateTimeUtc { get; set; }

    }
}

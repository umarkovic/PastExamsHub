using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;

namespace PastExamsHub.Core.Application.Common.Interfaces
{
    public interface ICoreDbContext : IApplicationDbContext
    {
    }
}

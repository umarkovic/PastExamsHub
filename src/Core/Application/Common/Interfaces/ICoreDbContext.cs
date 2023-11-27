using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;

namespace PastExamsHub.Core.Application.Common.Interfaces
{
    public interface ICoreDbContext : IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Exam> Exams { get; set; }
        DbSet<Core.Domain.Entities.ExamPeriod> ExamPeriods { get; set; }
    }
}

using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Infrastructure.Persistence;
using PastExamsHub.Authority.Application.Common.Interfaces;
using PastExamsHub.Authority.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using PastExamsHub.Base.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using PastExamsHub.Base.Domain.Enums;

namespace PastExamsHub.Authority.Infrastructure.Persistence
{
    public class AuthorityDbContext : IdentityDbContext<IdentityApplicationUser>, IAuthorityDbContext
    {
        public AuthorityDbContext(DbContextOptions<AuthorityDbContext> options) : base(options)
        {
        }

        public async Task Migrate()
        {
            if (Database.IsInMemory())
            {
                return;
            }

            await Database.MigrateAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            var schemaName = nameof(Microsoft.AspNetCore.Identity);
            builder.Entity<IdentityApplicationUser>().Metadata.SetSchema(schemaName);//base.Users
            builder.Entity<IdentityUserClaim<string>>().Metadata.SetSchema(schemaName);//base.UserClaims
            builder.Entity<IdentityUserToken<string>>().Metadata.SetSchema(schemaName);//base.UserTokens
            builder.Entity<IdentityUserLogin<string>>().Metadata.SetSchema(schemaName);//base.UserLogins
            builder.Entity<IdentityUserRole<string>>().Metadata.SetSchema(schemaName);//base.UserRoles
            builder.Entity<IdentityRole>().Metadata.SetSchema(schemaName);//base.Roles
            builder.Entity<IdentityRoleClaim<string>>().Metadata.SetSchema(schemaName);//base.RoleClaims

            Seed(builder);
        }

        //https://deblokt.com/2020/01/24/04-part-3-identityserver4-asp-net-core-identity-net-core-3-1/
        private void Seed(ModelBuilder builder)
        {
            SeedRole(builder, RoleType.Admin);
            SeedRole(builder, RoleType.Student);
            SeedRole(builder, RoleType.Teacher);

            SeedUser(builder, "Administrator", "System", "administrator@localhost", "Administrator1!", RoleType.Admin);
            SeedUser(builder, "Uros", "Markovic", "umarkovic864@gmail.com", "Administrator1!", RoleType.Student);
            SeedUser(builder, "Valentina", "Nejkovic", "valenejkovic@gmail.com", "Administrator1!", RoleType.Teacher);
        }

        void SeedRole(ModelBuilder builder, RoleType roleType)
        {
            var role = new IdentityRole<string>
            {
                Id = roleType.ToString(),
                Name = roleType.ToString(),
                NormalizedName = roleType.ToString().ToUpper()
            };
            builder.Entity<IdentityRole>().HasData(role);
        }

        int IdentityUserClaim_Id = 0;
        void SeedUser(ModelBuilder builder, string firstName, string lastName, string adminEmail, string adminPassword, RoleType roleType)
        {
            var user = new IdentityApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = adminEmail,
                NormalizedUserName = adminEmail.ToUpperInvariant(),
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                EmailConfirmed = true,

                FirstName = firstName,
                LastName = lastName,
                Role = roleType,
                PhoneNumber = "0",
            };
            user.PasswordHash = new PasswordHasher<IdentityApplicationUser>().HashPassword(user, adminPassword);

            builder.Entity<IdentityApplicationUser>().HasData
            (
                user
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = roleType.ToString(),
                    UserId = user.Id
                }
            );

            builder.Entity<IdentityUserClaim<string>>().HasData
            (
                new IdentityUserClaim<string>
                {
                    Id = ++IdentityUserClaim_Id,
                    UserId = user.Id,
                    ClaimType = "name",
                    ClaimValue = adminEmail
                },
                new IdentityUserClaim<string>
                {
                    Id = ++IdentityUserClaim_Id,
                    UserId = user.Id,
                    ClaimType = "email",
                    ClaimValue = adminEmail
                },
                new IdentityUserClaim<string>
                {
                    Id = ++IdentityUserClaim_Id,
                    UserId = user.Id,
                    ClaimType = "email_verified",
                    ClaimValue = true.ToString()
                }
            );
        }
    }
}
﻿using PastExamsHub.Base.Infrastructure;
using PastExamsHub.Core.Application.Common.Interfaces;
using PastExamsHub.Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Hosting;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Infrastructure.Services;
using PastExamsHub.Core.Infrastructure.Services;

namespace PastExamsHub.Core.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices
        (
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment
        )
        {
            Base.Infrastructure.Startup.ConfigureServices(services, configuration, environment);

            var coreDbContextOptionsBuilder = new Action<DbContextOptionsBuilder>(options => options.ConfigureDbContext<CoreDbContext>(configuration, environment));
            services.AddDbContext<CoreDbContext>(coreDbContextOptionsBuilder)
                .AddScoped<ICoreDbContext, CoreDbContext>();



            //IMPORTANT: always rely on ICoreDbContext (not CoreDbContext) because IoC will not inject the same scope instance !!!       
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddMemoryCache();//TODO: compare to AddDistributedMemoryCache
            services.AddTransient<IEmailTemplateService, EmailTemplateService>();
            services.AddTransient<IAuthorityService, AuthorityService>();


            return services;
        }
    }
}
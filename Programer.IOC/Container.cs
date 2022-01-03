using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Programer.Core.Services;
using Programer.Core.Utilities.Security;
using Programer.DataEF.ProgramersContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.IOC
{
    public static class Container
    {
        public static IServiceCollection AddIOCServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProgramerContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("ProgramerConnection"));
            });

            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductGroupService, ProductGroupService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IArticleGroupService, ArticleGroupService>();


            return services;
        }

    }
}


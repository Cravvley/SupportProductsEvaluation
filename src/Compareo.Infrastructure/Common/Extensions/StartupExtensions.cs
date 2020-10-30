using Compareo.Data.Repositories;
using Compareo.Infrastructure.Repositories;
using Compareo.Infrastructure.Services;
using Compareo.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Compareo.Data;
using Compareo.Infrastructure.Common.Extensions;
using Compareo.Infrastructure.Common.Options;
using Compareo.Infrastructure.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Net;
using System.Net.Mail;


namespace Compareo.Infrastructure.Common.Extensions
{
    public static class StartupExtensions
    {
        public static void AddOurServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSenderService>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IRateService, RateService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShopPropositionRepository, ShopPropositionRepository>();
            services.AddScoped<IShopPropositionService, ShopPropositionService>();
            services.AddScoped<IProductPropositionRepository, ProductPropositionRepository>();
            services.AddScoped<IProductPropositionService, ProductPropositionService>();
        }

        public static void AddFrameworkServices(this IServiceCollection services,IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });

            services.Configure<EmailSettings>(Configuration.GetSection("Email:Smtp"));
            services.AddScoped((serviceProvider) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                return new SmtpClient()
                {
                    Host = config.GetValue<string>("Email:Smtp:Host"),
                    Port = config.GetValue<int>("Email:Smtp:Port"),
                    EnableSsl = true,
                    Credentials = new NetworkCredential(
                        config.GetValue<string>("Email:Smtp:Username"),
                        config.GetValue<string>("Email:Smtp:Password")
                    ),
                };
            });
        }
    }
}

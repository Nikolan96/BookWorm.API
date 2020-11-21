using BookWorm.API.Quartz.Factory;
using BookWorm.API.Quartz.Jobs;
using BookWorm.API.Quartz.Scheduler;
using BookWorm.API.Quartz.Services;
using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities;
using BookWorm.Services.Services;
using BookWorm.Services.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace BookWorm.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("Bookworm")));
        }

        public static void AddIdentityServerConfig(this IServiceCollection services, IConfiguration Configuration)
        {
//            services.AddAuthentication(
//                IdentityServerAuthenticationDefaults.AuthenticationScheme)
//                .AddIdentityServerAuthentication(options =>
//                {
//                    options.Authority = Configuration.GetSection("Identity:IdentityServerBaseUrl").Value;
//                    options.ApiName = Configuration.GetSection("Api:Name").Value;
//#if RELEASE
//                    options.RequireHttpsMetadata = true;
//#else
//                    options.RequireHttpsMetadata = false;
//#endif
//                });
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IAuthorFactService, AuthorFactService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookAuthorService, BookAuthorService>();
            services.AddScoped<IBookCaseService, BookCaseService>();
            services.AddScoped<IBookFactService, BookFactService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICaseService, CaseService>();
            services.AddScoped<ICriticReviewService, CriticReviewService>();
            services.AddScoped<IReasonToReadService, ReasonToReadService>();
            services.AddScoped<IUserReviewService, UserReviewService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IUserBookNoteService, UserBookNoteService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IUserOpenedBookPageService, UserOpenedBookPageService>();
            services.AddScoped<IBooksReadService, BooksReadService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IPickOfTheDayService, PickOfTheDayService>();

            // Add Quartz services
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            // Add our job
            services.AddSingleton<PickOfTheDayJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(PickOfTheDayJob),
                cronExpression: "0 0/30 * 1/1 * ? *")); // run every 1 minute

            services.AddHostedService<QuartzHostedService>();
        }
    }
}

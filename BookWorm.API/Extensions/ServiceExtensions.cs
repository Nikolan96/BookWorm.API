using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities;
using BookWorm.Quartz.Factory;
using BookWorm.Quartz.Interfaces;
using BookWorm.Quartz.Services;
using BookWorm.Services.Services;
using BookWorm.Services.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Spi;
using System;

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
            services.AddDbContext<DataContext>(opts
                => opts.UseSqlServer(configuration.GetConnectionString("Bookworm")), ServiceLifetime.Transient);
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

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("Bookworm")), ServiceLifetime.Transient);
            services.AddTransient<Func<DataContext>>(options => () => options.GetService<DataContext>());
         

            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();

            services.AddTransient<Func<IPickOfTheDayService>>(options => () => options.GetService<IPickOfTheDayService>());
            services.AddTransient<Func<IPickOfTheWeekService>>(cont => () => cont.GetService<IPickOfTheWeekService>());
            services.AddTransient<Func<IBookService>>(cont => () => cont.GetService<IBookService>());

            services.AddTransient<IAuthorFactService, AuthorFactService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookAuthorService, BookAuthorService>();
            services.AddTransient<IBookCaseService, BookCaseService>();
            services.AddTransient<IBookFactService, BookFactService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICaseService, CaseService>();
            services.AddTransient<ICriticReviewService, CriticReviewService>();
            services.AddTransient<IReasonToReadService, ReasonToReadService>();
            services.AddTransient<IUserReviewService, UserReviewService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IUserBookNoteService, UserBookNoteService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IUserOpenedBookPageService, UserOpenedBookPageService>();
            services.AddTransient<IBooksReadService, BooksReadService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<IPickOfTheDayService, PickOfTheDayService>();
            services.AddTransient<IPickOfTheWeekService, PickOfTheWeekService>();
            services.AddTransient<IAchievementService, AchievementService>();
            services.AddTransient<IUserAchievementService, UserAchievementService>();
            services.AddTransient<IAwardAchievementService, AwardAchievementService>();
            services.AddTransient<IUserCurrentlyReadingService, UserCurrentlyReadingService>();
            services.AddTransient<ILevelingService, LevelingService>();

            // Add Quartz services
            services.AddSingleton<ISchedulerFactory>(new StdSchedulerFactory());
            services.AddSingleton<IJobFactory>(new SimpleJobFactory());
            services.AddSingleton<IQuartzTriggerFactory>(new QuartzTriggerFactory());

            services.AddHostedService<QuartzHostedService>();
        }
    }
}

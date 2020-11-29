using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Quartz.Factory;
using BookWorm.Quartz.Interfaces;
using BookWorm.Services.Services;
using BookWorm.Services.Wrapper;
using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Spi;
using Unity;

namespace BookWorm.API.Unity
{
    internal static class Bootstrapper
    {
        public static void Initialize(IUnityContainer container)
        {
            container.RegisterType<IRepositoryWrapper, RepositoryWrapper>();
            container.RegisterType<IAuthorFactService, AuthorFactService>();
            container.RegisterType<IAuthorService, AuthorService>();
            container.RegisterType<IBookAuthorService, BookAuthorService>();
            container.RegisterType<IBookCaseService, BookCaseService>();
            container.RegisterType<IBookFactService, BookFactService>();
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<ICaseService, CaseService>();
            container.RegisterType<ICriticReviewService, CriticReviewService>();
            container.RegisterType<IReasonToReadService, ReasonToReadService>();
            container.RegisterType<IUserReviewService, UserReviewService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAddressService, AddressService>();
            container.RegisterType<IUserBookNoteService, UserBookNoteService>();
            container.RegisterType<IGenreService, GenreService>();
            container.RegisterType<IUserOpenedBookPageService, UserOpenedBookPageService>();
            container.RegisterType<IBooksReadService, BooksReadService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IPublisherService, PublisherService>();
            container.RegisterType<IPickOfTheDayService, PickOfTheDayService>();
            container.RegisterType<IPickOfTheWeekService, PickOfTheWeekService>();
            container.RegisterType<IAchievementService, AchievementService>();
            container.RegisterType<IUserAchievementService, UserAchievementService>();
            container.RegisterType<IAwardAchievementService, AwardAchievementService>();

            // Add Quartz services
            container.RegisterInstance<ISchedulerFactory>(new StdSchedulerFactory());
            container.RegisterInstance<IJobFactory>(new SimpleJobFactory());
            container.RegisterInstance<IQuartzTriggerFactory>(new QuartzTriggerFactory());
        }
    }
}

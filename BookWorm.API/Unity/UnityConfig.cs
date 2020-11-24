using System;
using Unity;

namespace BookWorm.API.Unity
{
    internal static class UnityConfig
    {
        public static IUnityContainer Container => _container.Value;

        private static Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return _container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            InitLogger(container);
            Bootstrapper.Initialize(container);
        }
        private static void InitLogger(IUnityContainer container)
        {
            //var newPath = Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, "Localization_API_log.txt");
            //ILogger log = new LoggerConfiguration()
            //        .WriteTo.File(newPath)
            //        .CreateLogger();

            //Log.Logger = log;
        }
    }
}

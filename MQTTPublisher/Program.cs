using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MQTTPublisher
{
    internal static class Program
    {
        //申明全局服务提供者
        public static IServiceProvider? serviceProvider
        {
            get;
            set;
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //支持依赖注入
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
            Application.Run(new Main());
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureServices(ServiceCollection services)
        {
            ////App
            //services.ApplicationServiceIoC();
            ////Infra

            ////Repo
            //services.InfrastructureORM<DapperIoC>();
            //注入log4net
            services.AddLogging(builder =>
            {
                builder.AddLog4Net(new Log4NetProviderOptions()
                {
                    Log4NetConfigFileName = "log4net.config",
                    Watch = true
                });
            });

            //窗体注入，需要使用依赖注入，必须将窗体在此处注入

        }
    }
}
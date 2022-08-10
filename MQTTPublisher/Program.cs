using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MQTTPublisher
{
    internal static class Program
    {
        //����ȫ�ַ����ṩ��
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
            //֧������ע��
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
            Application.Run(new Main());
        }

        /// <summary>
        /// ����ע��
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureServices(ServiceCollection services)
        {
            ////App
            //services.ApplicationServiceIoC();
            ////Infra

            ////Repo
            //services.InfrastructureORM<DapperIoC>();
            //ע��log4net
            services.AddLogging(builder =>
            {
                builder.AddLog4Net(new Log4NetProviderOptions()
                {
                    Log4NetConfigFileName = "log4net.config",
                    Watch = true
                });
            });

            //����ע�룬��Ҫʹ������ע�룬���뽫�����ڴ˴�ע��

        }
    }
}
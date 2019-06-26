using Autofac;
using Autofac.Extras.Quartz;
using NotifyChangeIp.Factories;
using NotifyChangeIp.Repositories;
using System.Threading;

namespace NotifyChangeIp.DependencyInjectionRegisters
{
    public class DependencyInjection
    {
        public static IContainer Configure(CancellationTokenSource cancellationTokenSource)
        {
            var containerBuilder = new ContainerBuilder();

            // Register quartz
            containerBuilder.Register(x => cancellationTokenSource.Token).SingleInstance();
            containerBuilder.RegisterModule(new QuartzAutofacJobsModule(typeof(Scheduler).Assembly));
            containerBuilder.RegisterModule(new QuartzAutofacFactoryModule());

            // Register repositories
            containerBuilder.RegisterType<NotifyIpRepository>().AsImplementedInterfaces();

            // Register factories
            containerBuilder.RegisterType<MailNotifyIpFactory>().Keyed<IProcessNotifyIp>(ActionsNotifyIpFactory.MailNotifyIp);

            return containerBuilder.Build();
        }
    }
}
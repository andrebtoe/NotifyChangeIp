using Topshelf;

namespace NotifyChangeIp
{
    public class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<Scheduler>(service =>
                {
                    service.ConstructUsing(settings => new Scheduler());
                    service.WhenStarted(ag => ag.Start());
                    service.WhenStopped(ag => ag.Stop());
                });

                x.SetDisplayName(Settings.NameService);
                x.SetServiceName(Settings.NameService);
                x.SetDescription("Service to monitor host ip");
                x.StartAutomaticallyDelayed();
            });
        }
    }
}
using System.Diagnostics;
using Topshelf;

namespace NotifyChangeIp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var erros = Settings.Validate();

            //using (EventLog eventLog = new EventLog("Application"))
            //{
            //    eventLog.Source = "NotifyChangeIp";
            //    eventLog.WriteEntry("Log message example", EventLogEntryType.Error);
            //}

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
using Autofac;
using NotifyChangeIp.DependencyInjectionRegisters;
using NotifyChangeIp.Jobs;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace NotifyChangeIp
{
    public class Scheduler
    {
        private IContainer _container;
        private CancellationTokenSource _tokenSource;

        public void Start()
        {
            _tokenSource = new CancellationTokenSource();
            _container = DependencyInjection.Configure(_tokenSource);

            ConfigureScheduler();
        }

        public void Stop()
        {
            try
            {
                // Get scheduler
                var scheduler = _container.Resolve<IScheduler>();

                // Cancel task
                _tokenSource.Cancel();
                scheduler.Shutdown(true);

                // Force dispose
                _container.Dispose();

                // Set event log
                using (var eventLog = new EventLog("Application"))
                {
                    eventLog.Source = Settings.NameService;
                    eventLog.WriteEntry("Servico stop", EventLogEntryType.Information);
                }
            }
            catch (Exception ex)
            {
                using (var eventLog = new EventLog("Application"))
                {
                    eventLog.Source = Settings.NameService;
                    eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
                }
            }
        }

        private IList<Tuple<IJobDetail, ITrigger>> GetConfigureJobs()
        {
            // Get timeService from parameters
            var timeService = Settings.TimeService;

            var jobs = new List<Tuple<IJobDetail, ITrigger>>();

            // job and trigger of notifyIp
            var notifyIpJobJob = JobBuilder.Create<NotifyIpJob>().Build();
            var triggerForNotifyIpJobJob = TriggerBuilder.Create().WithSimpleSchedule(s => s.RepeatForever().WithIntervalInSeconds((int)timeService.TotalSeconds).WithMisfireHandlingInstructionIgnoreMisfires())
                                                                  .StartNow()
                                                                  .Build();

            // Create tuple
            var tupleJobNotifyIp = new Tuple<IJobDetail, ITrigger>(notifyIpJobJob, triggerForNotifyIpJobJob);

            // Add job notifyIp
            jobs.Add(tupleJobNotifyIp);

            return jobs;
        }

        private void ConfigureScheduler()
        {
            // Jobs to configure
            var jobs = GetConfigureJobs();

            // Configure scheduler task and jobs
            var scheduler = _container.Resolve<IScheduler>();

            // Add jobs in scheduler
            foreach (var job in jobs)
                scheduler.ScheduleJob(job.Item1, job.Item2);

            // Start scheduler
            scheduler.Start();
        }
    }
}
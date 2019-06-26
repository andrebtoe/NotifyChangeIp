using Autofac.Features.Indexed;
using NotifyChangeIp.Factories;
using NotifyChangeIp.Repositories;
using Quartz;
using System.Threading.Tasks;

namespace NotifyChangeIp.Jobs
{
    [DisallowConcurrentExecution]
    public class NotifyIpJob : IJob
    {
        private readonly INotifyIpRepository _notifyIpRepository;
        private readonly IIndex<ActionsNotifyIpFactory, IProcessNotifyIp> _iindexProcessNotifyIp;

        public NotifyIpJob(INotifyIpRepository notifyIpRepository, IIndex<ActionsNotifyIpFactory, IProcessNotifyIp> iindexProcessNotifyIp)
        {
            _notifyIpRepository = notifyIpRepository;
            _iindexProcessNotifyIp = iindexProcessNotifyIp;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            // Check ip
            var internetHasChanged = await _notifyIpRepository.IpInternetHasChangedAsync();

            if (internetHasChanged)
            {
                // Get ipv4 from internet
                var ipV4Internet = await _notifyIpRepository.GetIpInternetAsync();

                // Store ipv4
                _notifyIpRepository.SaveIpInternet(ipV4Internet);

                // Get type and factory
                var type = Settings.Type;
                var processNotifyIp = _iindexProcessNotifyIp[type];

                // Execute process
                await processNotifyIp.ExecuteAsync(ipV4Internet);
            }
        }
    }
}
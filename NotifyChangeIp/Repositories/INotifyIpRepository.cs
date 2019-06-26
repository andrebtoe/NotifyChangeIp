using System.Net;
using System.Threading.Tasks;

namespace NotifyChangeIp.Repositories
{
    public interface INotifyIpRepository
    {
        void SaveIpInternet(IPAddress ipAddress);
        Task<bool> IpInternetHasChangedAsync();
        Task<IPAddress> GetIpInternetAsync();
    }
}
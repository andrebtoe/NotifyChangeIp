using System.Net;
using System.Threading.Tasks;

namespace NotifyChangeIp.Factories
{
    public interface IProcessNotifyIp
    {
        Task ExecuteAsync(IPAddress ipAddress);
    }
}
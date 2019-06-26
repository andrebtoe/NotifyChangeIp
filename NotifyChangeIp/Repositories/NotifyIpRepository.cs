using Microsoft.Win32;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotifyChangeIp.Repositories
{
    public class NotifyIpRepository : INotifyIpRepository
    {
        public const string subKey = @"SOFTWARE\NotifyChangeIp";
        public const string nameSubKey = "Ipv4Internet";

        public void SaveIpInternet(IPAddress ipAddress)
        {
            // Get subKey
            var registry = Registry.CurrentUser.CreateSubKey(subKey);

            // Set value ip
            registry.SetValue(nameSubKey, ipAddress);
            registry.Close();
        }

        public async Task<bool> IpInternetHasChangedAsync()
        {
            var ipv4Internet = await GetIpInternetAsync();
            var ipV4Saved = GetIpV4Saved();

            if (ipV4Saved == null)
                return true;
            else
                return ipv4Internet != ipV4Saved;
        }

        public async Task<IPAddress> GetIpInternetAsync()
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync("https://api.ipify.org");
            var ip = await httpResponse.Content.ReadAsStringAsync();
            var ipAddress = IPAddress.Parse(ip);

            return ipAddress;
        }

        private IPAddress GetIpV4Saved()
        {
            var registry = Registry.CurrentUser.OpenSubKey(subKey);
            if (registry == null)
                return null;

            var ipv4 = registry.GetValue(nameSubKey);
            if (ipv4 == null)
                return null;

            return IPAddress.Parse(ipv4.ToString());
        }
    }
}
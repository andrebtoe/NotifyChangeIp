using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NotifyChangeIp.Factories
{
    public class MailNotifyIpFactory : IProcessNotifyIp
    {
        public async Task ExecuteAsync(IPAddress ipAddress)
        {
            using (var smtpClient = new SmtpClient(Settings.HostAuth))
            {
                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(Settings.MailAuth);
                mailMessage.To.Add(Settings.EmailTo);
                mailMessage.Subject = String.Format("{0} - {1}", Settings.Title, Settings.Identify);
                mailMessage.Body = ipAddress.ToString();
                smtpClient.EnableSsl = Settings.SslAuth;
                smtpClient.Port = Settings.PortAuth;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(Settings.MailAuth, Settings.PasswordAuth);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
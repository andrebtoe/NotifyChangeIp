using NotifyChangeIp.Factories;
using NotifyChangeIp.SpecificationsValidations;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace NotifyChangeIp
{
    public class Settings
    {
        private static NameValueCollection _appSettings = ConfigurationManager.AppSettings;
        private const string NameServiceNameKey = "nameService";
        private const string TimeServiceNameKey = "timeService";
        private const string TypeNameKey = "type";
        private const string LogsNameKey = "logs";
        private const string IdentifyNameKey = "identify";
        private const string TitleNameKey = "title";
        private const string HostAuthNameKey = "hostAuth";
        private const string MailAuthNameKey = "mailAuth";
        private const string PasswordAuthNameKey = "passwordAuth";
        private const string SslAuthNameKey = "sslAuth";
        private const string PortAuthNameKey = "portAuth";
        private const string EmailToNameKey = "emailTo";

        public static string NameService
        {
            get
            {
                return _appSettings[NameServiceNameKey] as string;
            }
        }

        public static TimeSpan TimeService
        {
            get
            {
                return TimeSpan.Parse(_appSettings[TimeServiceNameKey]);
            }
        }

        public static ActionsNotifyIpFactory Type
        {
            get
            {
                return (ActionsNotifyIpFactory)Enum.Parse(typeof(ActionsNotifyIpFactory), _appSettings[TypeNameKey]);
            }
        }

        public static bool Logs
        {
            get
            {
                return Boolean.Parse(_appSettings[LogsNameKey]);
            }
        }

        public static string Identify
        {
            get
            {
                return _appSettings[IdentifyNameKey] as string;
            }
        }

        public static string Title
        {
            get
            {
                return _appSettings[TitleNameKey] as string;
            }
        }

        public static string HostAuth
        {
            get
            {
                return _appSettings[HostAuthNameKey] as string;
            }
        }

        public static string MailAuth
        {
            get
            {
                return _appSettings[MailAuthNameKey] as string;
            }
        }

        public static string PasswordAuth
        {
            get
            {
                return _appSettings[PasswordAuthNameKey] as string;
            }
        }

        public static bool SslAuth
        {
            get
            {
                return Boolean.Parse(_appSettings[SslAuthNameKey]);
            }
        }

        public static int PortAuth
        {
            get
            {
                return Int32.Parse(_appSettings[PortAuthNameKey]);
            }
        }

        public static string EmailTo
        {
            get
            {
                return _appSettings[EmailToNameKey];
            }
        }

        public static List<string> Validate()
        {
            // Create list errors
            var erros = new List<string>();

            // Add SpecificationValidation
            SpecificationValidationValidationType.AddValidateByRef(_appSettings[TypeNameKey], ref erros);
            SpecificationValidationValidationLogs.AddValidateByRef(_appSettings[LogsNameKey], ref erros);

            if (erros.Count == 0 && Type == ActionsNotifyIpFactory.MailNotifyIp)
            {
                SpecificationValidationNameService.AddValidateByRef(NameService, ref erros);
                SpecificationValidationTimeService.AddValidateByRef(_appSettings[TimeServiceNameKey], ref erros);
                SpecificationValidationIdentify.AddValidateByRef(IdentifyNameKey, ref erros);
                SpecificationValidationTitle.AddValidateByRef(Title, ref erros);
                SpecificationValidationHostAuth.AddValidateByRef(HostAuthNameKey, ref erros);
                SpecificationValidationPasswordAuth.AddValidateByRef(PasswordAuthNameKey, ref erros);
                SpecificationValidationSslAuth.AddValidateByRef(_appSettings[SslAuthNameKey], ref erros);
                SpecificationValidationPort.AddValidateByRef(_appSettings[PortAuthNameKey], ref erros);
                SpecificationValidationEmailTo.AddValidateByRef(EmailTo, ref erros);
                // _appSettings[LogsKey]
            }

            return erros;
        }
    }
}
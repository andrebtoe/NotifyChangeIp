using System;
using System.Collections.Generic;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationValidationLogs
    {
        public static void AddValidateByRef(string logs, ref List<string> erros)
        {
            bool logsBoolean;
            var logsValid = Boolean.TryParse(logs, out logsBoolean);
            if (!logsValid)
                erros.Add("'logs' invalid");
        }
    }
}
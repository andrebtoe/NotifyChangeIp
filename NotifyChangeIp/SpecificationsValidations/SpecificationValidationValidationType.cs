using NotifyChangeIp.Factories;
using System;
using System.Collections.Generic;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationValidationType
    {
        public static void AddValidateByRef(string type, ref List<string> erros)
        {
            ActionsNotifyIpFactory actionsNotifyIpFactory;
            var actionsNotifyIpFactoryValid = Enum.TryParse(type, out actionsNotifyIpFactory);

            if (!actionsNotifyIpFactoryValid)
                erros.Add("'type' invalid in config");
        }
    }
}
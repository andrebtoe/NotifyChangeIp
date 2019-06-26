using System;
using System.Collections.Generic;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationIdentify
    {
        public static void AddValidateByRef(string identify, ref List<string> erros)
        {
            var identifyValid = String.IsNullOrEmpty(identify);
            if (identifyValid)
                erros.Add("'identify' must be defined");
        }
    }
}
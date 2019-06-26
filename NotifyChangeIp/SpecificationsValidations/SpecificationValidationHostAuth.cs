using System;
using System.Collections.Generic;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationHostAuth
    {
        public static void AddValidateByRef(string hostAuth, ref List<string> erros)
        {
            var hostAuthValid = String.IsNullOrEmpty(hostAuth);
            if (hostAuthValid)
                erros.Add("'hostAuth' must be defined");
        }
    }
}
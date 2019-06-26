using System;
using System.Collections.Generic;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationPasswordAuth
    {
        public static void AddValidateByRef(string passwordAuth, ref List<string> erros)
        {
            var passwordAuthValid = String.IsNullOrEmpty(passwordAuth);
            if (passwordAuthValid)
                erros.Add("'passwordAuth' must be defined");
        }
    }
}
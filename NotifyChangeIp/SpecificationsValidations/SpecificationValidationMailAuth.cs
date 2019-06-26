using System;
using System.Collections.Generic;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationMailAuth
    {
        public static void AddValidateByRef(string mailAuth, ref List<string> erros)
        {
            var mailAuthValid = String.IsNullOrEmpty(mailAuth);
            if (mailAuthValid)
                erros.Add("'mailAuth' must be defined");
        }
    }
}
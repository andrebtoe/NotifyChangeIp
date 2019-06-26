using System;
using System.Collections.Generic;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationSslAuth
    {
        public static void AddValidateByRef(string sslAuth, ref List<string> erros)
        {
            bool sslAuthBoolean;
            var sslAuthValid = Boolean.TryParse(sslAuth, out sslAuthBoolean);
            if (!sslAuthValid)
                erros.Add("'sslAuth' invalid");
        }
    }
}
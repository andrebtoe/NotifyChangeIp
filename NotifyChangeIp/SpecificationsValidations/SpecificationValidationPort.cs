using System;
using System.Collections.Generic;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationPort
    {
        public static void AddValidateByRef(string portAuth, ref List<string> erros)
        {
            int portAuthInt32;
            var portAuthValid = Int32.TryParse(portAuth, out portAuthInt32);
            if (!portAuthValid)
                erros.Add("'portAuth' invalid");
        }
    }
}
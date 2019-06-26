using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationEmailTo
    {
        public static void AddValidateByRef(string emailTo, ref List<string> erros)
        {
            var emailToValid = String.IsNullOrEmpty(emailTo);
            if (emailToValid)
            {
                erros.Add("'emailTo' must be defined");
            }
            else
            {
                bool emailValid = Regex.IsMatch(emailTo, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!emailValid)
                    erros.Add("'emailTo' invalid");
            }
        }
    }
}
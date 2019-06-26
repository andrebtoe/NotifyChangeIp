using System;
using System.Collections.Generic;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationTitle
    {
        public static void AddValidateByRef(string title, ref List<string> erros)
        {
            var titleValid = String.IsNullOrEmpty(title);
            if (titleValid)
                erros.Add("'title' must be defined");
        }
    }
}
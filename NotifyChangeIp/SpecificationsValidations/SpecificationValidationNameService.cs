using System;
using System.Collections.Generic;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationNameService
    {
        public static void AddValidateByRef(string nameService, ref List<string> erros)
        {
            var nameServiceValid = String.IsNullOrEmpty(nameService);
            if (nameServiceValid)
                erros.Add("'nameService' must be defined");
        }
    }
}
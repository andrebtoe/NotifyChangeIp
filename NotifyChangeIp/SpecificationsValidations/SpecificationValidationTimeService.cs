using System;
using System.Collections.Generic;

namespace NotifyChangeIp.SpecificationsValidations
{
    public class SpecificationValidationTimeService
    {
        public static void AddValidateByRef(string timeService, ref List<string> erros)
        {
            var timeServiceValid = String.IsNullOrEmpty(timeService);
            if (timeServiceValid)
            {
                erros.Add("'timeService' must be defined");
            }
            else
            {
                TimeSpan timeSpan;
                var timeSpanValid = TimeSpan.TryParse(timeService, out timeSpan);
                if (!timeSpanValid)
                    erros.Add("'timeService' value invalid");
            }
        }
    }
}
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Utility
{
    /// <summary>
    /// DateTime Property converter, for simpler DateTimeformat.
    /// </summary>
    public class CustomTimeConverter : IsoDateTimeConverter
    {
        public CustomTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MoviesAPI
{
    public static class MovieHelper
    {
        public static int? TryGetIntParameterFromRequest(HttpRequestMessage httpRequest, string paramName)
        {
            if (httpRequest.Headers.TryGetValues(paramName, out IEnumerable<string> paramValues))
            {
                var paramValue = paramValues.FirstOrDefault(o => !string.IsNullOrWhiteSpace(o));
                if (paramValue != null && Int32.TryParse(paramValue, out int paramIntValue))
                {
                    return paramIntValue;
                }
            }
            return null;
        }
    }
}
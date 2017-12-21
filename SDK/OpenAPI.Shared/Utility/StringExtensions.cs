using System;
using System.Collections.Generic;
using System.Linq;

namespace KKBOX.OpenAPI
{
    internal static class StringExtensions
    {
        internal static Dictionary<string, string> ToKeyValueDictionary(this string param)
        {
            try
            {
                var splitArray = param.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                if (splitArray == null || splitArray.Length == 0)
                {
                    return new Dictionary<string, string>();
                }

                var splitArray2 = splitArray.Select(part => part.Split('='));

                Dictionary<string, string> returnData = new Dictionary<string, string>();

                foreach (var item in splitArray2)
                {
                    var key = item[0];
                    var value = item.Length > 1 ? item[1] : string.Empty;
                    returnData.Add(key, value);
                }

                return returnData;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

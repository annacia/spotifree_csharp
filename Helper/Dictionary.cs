using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.Helper
{
    public class Dictionary
    {
        public string GetString(string key, Dictionary<string,string> data)
        {
            string keyValue;
            bool hasKey = data.TryGetValue(key, out keyValue);

            if (!hasKey)
            {
                return "";
            }

            return keyValue;
        }
    }
}
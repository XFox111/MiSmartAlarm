using System;
using System.Collections.Generic;
using System.Text;

namespace MiSmartAlarm
{
    public class Localization
    {
        public string this[string key] => dictionary[key];

        private Dictionary<string, string> dictionary;
    }
}

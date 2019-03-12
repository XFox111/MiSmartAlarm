using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace MiSmartAlarm
{
    public static class Storage
    {
        public static List<Alarm> Alarms { get; set; }

        public static void Load()
        {
            if (Application.Current.Properties.ContainsKey("alarms"))
            {
                string raw = Application.Current.Properties["alarms"].ToString();
                Alarms = JsonConvert.DeserializeObject<dynamic>(raw) as List<Alarm>;
            }
            //    Alarms = JsonConvert.DeserializeObject<List<Alarm>>(Application.Current.Properties["alarms"] as string);
            else
            {
                Alarms = new List<Alarm>();
                Save();
            }
        }
        public static void Save()
        {
            Application.Current.Properties["alarms"] = JsonConvert.SerializeObject(Alarms);
        }
    }
}

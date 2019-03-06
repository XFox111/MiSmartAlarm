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
            try
            {
                if (Application.Current.Properties.ContainsKey("alarms"))
                    Alarms = JsonConvert.DeserializeObject<List<Alarm>>(Application.Current.Properties["alarms"] as string);
                else
                    throw new Exception();
            }
            catch
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

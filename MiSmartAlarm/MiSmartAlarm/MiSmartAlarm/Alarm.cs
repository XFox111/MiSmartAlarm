using System;
using System.Collections.Generic;

namespace MiSmartAlarm
{
    public enum AlarmType { MiSmart, Default, Timer, Smart }
    public class Alarm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = false;
        public AlarmType Type { get; set; } = AlarmType.Default;
        public TimeSpan Time { get; set; } = TimeSpan.FromHours(8);
        public TimeSpan EndTime { get; set; } = TimeSpan.FromHours(20);
        public TimeSpan Interval { get; set; } = TimeSpan.FromMinutes(20);
        public Dictionary<string, bool> Days => new Dictionary<string, bool>()
        {
            { "sunday", true },
            { "monday", true },
            { "tuesday", true },
            { "wednesday", true },
            { "thursday", true },
            { "friday", true },
            { "saturday", true },
        };

        public string Icon => IsEnabled ? "on.png" : "off.png";

        public Alarm()
        {
            Id = Storage.Alarms.Count;
            Name = $"{"Alarm"} {Id}";
        }
    }
}

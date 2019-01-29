using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiSmartAlarm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmPage : ContentPage
    {
        Alarm Alarm { get; set; } = new Alarm();
        public AlarmPage(Alarm alarm = null)
        {
            InitializeComponent();
            if (alarm != null)
                Alarm = alarm;

            name.Text = Alarm.Name;
            enabled.IsToggled = Alarm.IsEnabled;

            // TODO: Reassign type on band detection
            type.SelectedIndex = (int)Alarm.Type;

            switch (Alarm.Type)
            {
                case AlarmType.Timer:
                    time.IsVisible = false;
                    startAt.Time = Alarm.Time;
                    endAt.Time = Alarm.EndTime;
                    interval.Time = Alarm.Interval;
                    break;

                default:
                    startAt.IsVisible = false;
                    endAt.IsVisible = false;
                    interval.IsVisible = false;
                    time.Time = Alarm.Time;
                    break;
            }

            foreach (var i in Alarm.Days)
                ((Switch)FindByName(i.Key)).IsToggled = i.Value;
        }

        private void Save_Activated(object sender, EventArgs e)
        {
            Alarm.Name = name.Text;
            Alarm.IsEnabled = enabled.IsToggled;
            Alarm.Type = (AlarmType)type.SelectedIndex;

            switch (Alarm.Type)
            {
                case AlarmType.Timer:
                    Alarm.Time = startAt.Time;
                    Alarm.EndTime = endAt.Time;
                    Alarm.Interval = interval.Time;
                    break;

                default:
                    Alarm.Time = time.Time;
                    break;
            }

            foreach (var i in Alarm.Days)
                Alarm.Days[i.Key] = ((Switch)FindByName(i.Key)).IsToggled;

            // TODO: Save configuration
            if (Alarm.IsEnabled)
            {
                // TODO: Set alarm
            }
            // TODO: Send notification

            Navigation.RemovePage(this);
        }

        private void Delete_Activated(object sender, EventArgs e)
        {
            // TODO: Delete alarm
        }
    }
}
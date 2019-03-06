using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiSmartAlarm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Github_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://github.com/xfox111/mismartalarm/"));
        }

        private void Donate_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://github.com/xfox111/mismartalarm/"));
        }

        private void Website_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://michael-xfox.com/"));
        }
    }
}
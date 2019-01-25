using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiSmartAlarm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void SettingsButton_Activated(object sender, EventArgs e)
        {

        }

        private void AboutButton_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }
    }
}

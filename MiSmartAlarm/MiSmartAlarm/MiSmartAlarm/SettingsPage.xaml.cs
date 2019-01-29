using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiSmartAlarm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            // TODO: Save settings

            //MessagingCenter.Send(this, "Saved");
            Navigation.RemovePage(this);
        }

        private void MacFill_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "Your MAC address has been retireved form MiFit app");
        }

        private void CheckMac_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "Your MiBand should now vibrate");
        }

        private void CheckAlarm_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "Your MiBand should now vibrate");
        }
    }
}
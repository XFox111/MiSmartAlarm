using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MiSmartAlarm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private async void SettingsButton_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void AboutButton_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        private async void Add_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlarmPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshList();
        }

        void RefreshList()
        {
            list.Children.Clear();
            foreach (Alarm i in Storage.Alarms)
            {
                Grid root = new Grid();
                TapGestureRecognizer recognizer = new TapGestureRecognizer
                {
                    CommandParameter = i,
                    NumberOfTapsRequired = 1
                };
                StackLayout content = new StackLayout();
                StackLayout days = new StackLayout { Orientation = StackOrientation.Horizontal };
                recognizer.Tapped += Recognizer_Tapped;

                root.GestureRecognizers.Add(recognizer);

                root.ColumnDefinitions.Add(new ColumnDefinition());
                root.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                root.Padding = new Thickness(10);
                root.Children.Add(new Image
                {
                    WidthRequest = 48,
                    HeightRequest = 48,
                    HorizontalOptions = LayoutOptions.End,
                    Source = i.IsEnabled ? "on.png" : "off.png"
                });

                content.Children.Add(new Label
                {
                    Text = i.Time.ToString(@"hh\:mm"),
                    FontSize = 50,
                    TextColor = Color.White
                });
                content.Children.Add(new Label { Text = i.Type.ToString() });

                foreach (KeyValuePair<string, bool> d in i.Days)
                    if (d.Value)
                        days.Children.Add(new Label
                        {
                            Text = d.Key.Remove(3).ToUpperInvariant(),
                            TextColor = Color.White
                        });

                content.Children.Add(days);
                root.Children.Add(content);
                Grid.SetColumn(root.Children[0], 1);
                list.Children.Add(root);
            }

            if (Storage.Alarms.Count == 0)
                list.Children.Add(new Label
                {
                    Text = "You have no configured alarms. Press '+' to add one.",
                    HorizontalOptions = LayoutOptions.Center,
                    LineBreakMode = LineBreakMode.WordWrap,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                });
        }

        private async void Recognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlarmPage((e as TappedEventArgs).Parameter as Alarm));
        }
    }
}

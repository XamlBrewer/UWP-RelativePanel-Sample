using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace XamlBrewer.Uwp.RelativePanelSample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Check if Boo is right of Kevin
            var theRightStuff = RelativePanel.GetRightOf(Stuart);

            // We'll check for Boo, not Kevin
            // The first call this returns the string "Kevin", only later it returns the Image "Kevin".

            // Historic C#
            // if (theRightStuff is Image && ((String)((Image)theRightStuff).Tag) == "Boo") // 

            // New C#
            if ((theRightStuff as Image)?.Tag?.ToString() == "Boo")
            {
                // Remove Boo
                RelativePanel.SetRightOf(Stuart, Kevin);
                MinionPanel.Children.Remove((UIElement)theRightStuff);
            }
            else
            {   // Insert Boo
                var boo = new Image()
                {
                    Source = new BitmapImage(new Uri("ms-appx:/Assets/Boo.png")),
                    Width = 300,
                    Tag = "Boo"
                };

                // Prepare Boo
                RelativePanel.SetRightOf(boo, Kevin);
                RelativePanel.SetAlignBottomWith(boo, Kevin);

                // Add Boo
                MinionPanel.Children.Add(boo);
                
                // Link to Stuart
                // Don't do this - it does not draw Boo (Stuart still has RightOf Kevin):
                // RelativePanel.SetLeftOf(boo, Stuart);

                // Override the graph edge:
                RelativePanel.SetRightOf(Stuart, boo);
            }
        }
    }
}

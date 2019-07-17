using System;
using System.Media;
using System.Windows;
using System.Windows.Media;

namespace ClipCop
{
    public partial class MainWindow : Window
    {
        public string currentClipboard;
        public string oldClipboard;
        public bool clipboardUpdated = false;
        public bool monitoringEnabled = true;
        public string soundOption = "1";

        // get the clipboard contents
        public string GetClipboard()
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    string ClipboardText = Clipboard.GetText();
                    return ClipboardText;
                }
                catch { }
                System.Threading.Thread.Sleep(10);
            }
            return null;
        }

        public MainWindow()
        {
            InitializeComponent();
            if (Clipboard.ContainsText())
            {
                currentClipboard = GetClipboard();
            } else
            {
                currentClipboard = "-- Empty or non-text content --";
            }
            clipboardContents.Text = currentClipboard;
            oldClipboard = currentClipboard;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var windowClipboardManager = new ClipMon(this);
            windowClipboardManager.ClipboardChanged += ClipboardChanged;
        }

        // set audio option
        private void sound1_Click(object sender, RoutedEventArgs e)
        {
            soundOption = "1";
            sound1.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            sound2.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF707070"));
            soundOff.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF707070"));
            sound1.FontWeight = FontWeights.Bold;
            sound2.FontWeight = FontWeights.Normal;
            soundOff.FontWeight = FontWeights.Normal;
        }

        private void sound2_Click(object sender, RoutedEventArgs e)
        {
            soundOption = "2";
            sound1.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF707070"));
            sound2.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            soundOff.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF707070"));
            sound1.FontWeight = FontWeights.Normal;
            sound2.FontWeight = FontWeights.Bold;
            soundOff.FontWeight = FontWeights.Normal;
        }

        private void soundOff_Click(object sender, RoutedEventArgs e)
        {
            soundOption = "Off";
            sound1.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF707070"));
            sound2.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF707070"));
            soundOff.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            sound1.FontWeight = FontWeights.Normal;
            sound2.FontWeight = FontWeights.Normal;
            soundOff.FontWeight = FontWeights.Bold;
        }


        private void ClipboardChanged(object sender, EventArgs e)
        {
            if (monitoringEnabled == true)
            {
                if (Clipboard.ContainsText())
                {
                    oldClipboardContents.Text = oldClipboard;
                    clipboardContents.Text = GetClipboard();
                    oldClipboard = clipboardContents.Text.ToString();

                    var flasher = new FlashWindowHelper(Application.Current);
                    flasher.FlashApplicationWindow();
                } else
                {
                    oldClipboardContents.Text = oldClipboard;
                    clipboardContents.Text = "-- Non-text content --";
                    oldClipboard = clipboardContents.Text.ToString();

                    var flasher = new FlashWindowHelper(Application.Current);
                    flasher.FlashApplicationWindow();
                }

                // play sound
                if (soundOption == "1")
                {
                    SystemSounds.Beep.Play();
                } else if (soundOption == "2")
                {
                    SystemSounds.Hand.Play();
                } else
                {

                }
            }
        }

        // start/stop monitoring button
        private void buttonOnOff_Click(object sender, RoutedEventArgs e)
        {
            // stop
            if (monitoringEnabled == true)
            {
                labelStatus.Width = 123;
                labelStatus.Content = "Not enabled";
                labelStatus.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));
                buttonOnOff.Content = "Start monitoring";
                buttonOnOff.ToolTip = "Click to start clipboard monitoring";
                buttonOnOff.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0CE402"));
                clipboardContents.Text = "";
                oldClipboardContents.Text = "";
                monitoringEnabled = false;
                if (Clipboard.ContainsText())
                {
                    oldClipboard = "";
                }
                else
                {
                    oldClipboard = "-- Non-text content --";
                }
            } else

            // start
            {
                labelStatus.Width = 82;
                labelStatus.Content = "Enabled";
                labelStatus.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0CE402"));
                buttonOnOff.Content = "Stop monitoring";
                buttonOnOff.ToolTip = "Click to stop clipboard monitoring";
                buttonOnOff.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));
                monitoringEnabled = true;
                oldClipboardContents.Text = "";
                if (Clipboard.ContainsText())
                {
                    oldClipboard = GetClipboard();
                    clipboardContents.Text = GetClipboard();
                } else
                {
                    clipboardContents.Text = "-- Non-text content --";
                }
            }
        }

        // open the help screen
        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            helpScreenScroolViewer.ScrollToTop();
            helpScreen.Visibility = Visibility.Visible;
        }

        // close the help screen
        private void closeHelpButton_Click(object sender, RoutedEventArgs e)
        {
            helpScreen.Visibility = Visibility.Hidden;
        }

        // donate buttons
        private void btcButton_Click(object sender, RoutedEventArgs e)
        {
            string oc = clipboardContents.Text.ToString();
            Clipboard.SetText("1DQLbaxohsnXy575Y3uhabimkny2Vw3UrX");
            MessageBox.Show("Copied BTC address\n1DQLbaxohsnXy575Y3uhabimkny2Vw3UrX");
            oldClipboardContents.Text = oc;
        }

        private void ethButton_Click(object sender, RoutedEventArgs e)
        {
            string oc = clipboardContents.Text.ToString();
            Clipboard.SetText("0xb6aC512DeEAd27F607C80a6A249B7d5941A5a1eF");
            MessageBox.Show("Copied ETH address\n0xb6aC512DeEAd27F607C80a6A249B7d5941A5a1eF");
            oldClipboardContents.Text = oc;
        }

        private void ltcButton_Click(object sender, RoutedEventArgs e)
        {
            string oc = clipboardContents.Text.ToString();
            Clipboard.SetText("LYHLd1FzNZVy4kcNQdyGCGaVpgtMpho8yk");
            MessageBox.Show("Copied LTC address\nLYHLd1FzNZVy4kcNQdyGCGaVpgtMpho8yk");
            oldClipboardContents.Text = oc;
        }

        private void dogeButton_Click(object sender, RoutedEventArgs e)
        {
            string oc = clipboardContents.Text.ToString();
            Clipboard.SetText("DP69FaUzG8NBmnUNRoP7SU2mqsus3ELqgZ");
            MessageBox.Show("Copied DOGE address\nDP69FaUzG8NBmnUNRoP7SU2mqsus3ELqgZ");
            oldClipboardContents.Text = oc;
        }
    }
}

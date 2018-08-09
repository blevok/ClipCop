using System;
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
        // for some reason, copying from within the application screws up the old clipboard, so for now i'm just resetting after clicking a donate button
        private void btcButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("1DQLbaxohsnXy575Y3uhabimkny2Vw3UrX");
            MessageBox.Show("Copied BTC address\n1DQLbaxohsnXy575Y3uhabimkny2Vw3UrX");
            oldClipboardContents.Text = "";
        }

        private void ethButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("0xb6aC512DeEAd27F607C80a6A249B7d5941A5a1eF");
            MessageBox.Show("Copied ETH address\n0xb6aC512DeEAd27F607C80a6A249B7d5941A5a1eF");
            oldClipboardContents.Text = "";
        }

        private void ltcButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("LYHLd1FzNZVy4kcNQdyGCGaVpgtMpho8yk");
            MessageBox.Show("Copied LTC address\nLYHLd1FzNZVy4kcNQdyGCGaVpgtMpho8yk");
            oldClipboardContents.Text = "";
        }

        private void dogeButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("DP69FaUzG8NBmnUNRoP7SU2mqsus3ELqgZ");
            MessageBox.Show("Copied DOGE address\nDP69FaUzG8NBmnUNRoP7SU2mqsus3ELqgZ");
            oldClipboardContents.Text = "";
        }
    }
}

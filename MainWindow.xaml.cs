using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TwitchSaltier.Properties;

namespace TwitchSaltier
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string SaltString = "PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt";
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            if (Settings.Default.TimerInterval > TimeSpan.FromSeconds(0))
            {                
                SelectCmbValue(Settings.Default.TimerInterval.Seconds);
                timer.Interval = Settings.Default.TimerInterval;
            }
            else
            {
                SelectCmbValue(timer.Interval.Seconds);
                timer.Interval = Settings.Default.TimerPreselectedInterval;
            }
            timer.Tick += Timer_Tick;
        }

        private void SelectCmbValue(int seconds)
        {
            if (seconds == 3)
                cmbTimer.SelectedIndex = 0;
            else if (seconds == 5)
                cmbTimer.SelectedIndex = 1;
            else
                cmbTimer.SelectedIndex = 2;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            txbLogger.Text = "";
            timer.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(SaltString);
            txbLogger.Text = "Copied to clipboard!";
            timer.Start();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBoxItem value = (ComboBoxItem)cmbTimer.Items[cmbTimer.SelectedIndex];
            Settings.Default.TimerInterval = TimeSpan.FromSeconds(int.Parse(value.Content.ToString()));
            Settings.Default.Save();
            timer.Interval = Settings.Default.TimerInterval;
        }
    }
}

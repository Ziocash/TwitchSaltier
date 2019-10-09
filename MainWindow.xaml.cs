﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TwitchSaltier
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string SaltString = "PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt PJSalt";
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            txbLogger.Text = "";
            timer.Stop();
        }

        private DispatcherTimer timer = new DispatcherTimer();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(SaltString);
            txbLogger.Text = "Copied to clipboard!";
            timer.Start();
        }
    }
}

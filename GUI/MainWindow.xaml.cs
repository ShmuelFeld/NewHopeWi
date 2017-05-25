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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            img = new Image()
            {
                Source = new BitmapImage(new Uri("/../../resources/palace.gif", UriKind.Relative))
            };
        }

        private void SinglePlayer(object sender, RoutedEventArgs e)
        {
            SinglePlayer sp = new SinglePlayer();
            sp.Show();
            this.Close();
        }

        private void MultyPlayer(object sender, RoutedEventArgs e)
        {
            MultiPlayer mw = new MultiPlayer();
            if (ConnectionError.isError)
            {
                return;
            }
            mw.Show();
            this.Close();
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.Show();
            this.Close();
        }
    }
}
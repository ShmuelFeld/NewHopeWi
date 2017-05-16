using System;
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

        }

        private void SinglePlayer(object sender, RoutedEventArgs e)
        {
            SinglePlayer sp = new SinglePlayer();
            sp.Show();
            this.Close();
        }

        private void MultyPlayer(object sender, RoutedEventArgs e)
        {
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
        }

        private void Picture(object sender, RoutedEventArgs e)
        {

        }
    }
}
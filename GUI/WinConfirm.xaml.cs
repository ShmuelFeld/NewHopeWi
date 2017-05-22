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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for WinConfirm.xaml
    /// </summary>
    public partial class WinConfirm : Window
    {
        private SingleMaze sm;
        public WinConfirm(SingleMaze s)
        {
            InitializeComponent();
            this.sm = s;
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            sm.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

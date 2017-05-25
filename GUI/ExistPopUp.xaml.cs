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
    /// Interaction logic for ExistPopUp.xaml
    /// </summary>
    public partial class ExistPopUp : Window
    {
        public ExistPopUp()
        {
            InitializeComponent();
        }
        /// <summary>
        /// a winfow that represent in error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MultiPlayer mp = new MultiPlayer();
            mp.Show();
            this.Close();
        }
    }
}

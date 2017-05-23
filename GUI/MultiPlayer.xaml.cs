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
    /// Interaction logic for MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : Window
    {
        private MultiPlayerVM mpvm;
        public MultiPlayer()
        {
            InitializeComponent();
            MultiPlayerModel model = new MultiPlayerModel();
            mpvm = new MultiPlayerVM(model);
            this.DataContext = mpvm;
        }

        private void JoinGame_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            MultiPlayerMaze mpm = new MultiPlayerMaze();
            
        }
    }
}

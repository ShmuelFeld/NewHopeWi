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
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        private SinglePlayerVM spvm;
        public SinglePlayer()
        {
            InitializeComponent();
            ISinglePlayerModel model = new ApplicationSinglePlayerModel();
            spvm = new SinglePlayerVM(model);
            this.DataContext = spvm;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            spvm.SaveSettings();
            SingleMaze m = new SingleMaze(spvm.MazeRows, spvm.MazeRows);
            m.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

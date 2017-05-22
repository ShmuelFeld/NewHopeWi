using MazeLib;
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
    /// Interaction logic for SingleMaze.xaml
    /// </summary>
    public partial class SingleMaze : Window
    {
        public int MazeRows { get; set; }
        public int MazeCols { get; set; }
        public string MazeString { get; set; }
        public Position InitialPos { get; set; }
        public Position GoalPos { get; set; }
        private SingleMazeVM smVM;

        public SingleMaze()
        {
            InitializeComponent();
            smVM = new SingleMazeVM();
            this.DataContext = smVM;
           // this.KeyDown += MazeUC.Viewbox_KeyDown;
        }

        private void MainWin_Click(object sender, RoutedEventArgs e)
        {
            WinConfirm m = new WinConfirm(this);
            m.ShowDialog();
        }

        private void solve_Click(object sender, RoutedEventArgs e)
        {

        }

        private void startOver_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
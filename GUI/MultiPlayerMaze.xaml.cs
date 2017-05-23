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
    /// Interaction logic for MultiPlayerMaze.xaml
    /// </summary>
    public partial class MultiPlayerMaze : Window
    {
        public int MazeRows { get; set; }
        public int MazeCols { get; set; }
        public string MazeString { get; set; }
        public Position InitialPos { get; set; }
        public Position GoalPos { get; set; }
        private MultiPlayerMazeVM mpVM;

        public MultiPlayerMaze(string kind)
        {
            InitializeComponent();
            mpVM = new MultiPlayerMazeVM(kind);
            this.DataContext = mpVM;
            
        }
    }
}

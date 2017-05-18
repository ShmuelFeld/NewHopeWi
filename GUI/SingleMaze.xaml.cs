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
        private SingleMazeVM smVM;

        public SingleMaze()
        {

            //root.DataContext = this;
            //this.Rows = rows;
            //this.Cols = cols;
            InitializeComponent();
            smVM = new SingleMazeVM();
            
            this.DataContext = smVM;
            
            //smVM.StartGame();
           // this.MazeString = mazeChars.ToString();
          //  drawMaze();
        }
    }
    }

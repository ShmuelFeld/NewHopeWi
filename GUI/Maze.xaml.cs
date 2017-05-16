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
    /// Interaction logic for Maze.xaml
    /// </summary>
    public partial class Maze : UserControl
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public string MazeString { get; set; }

        public Maze(int rows, int cols, string mazeString)
        {
            InitializeComponent();
            this.Rows = rows;
            this.Cols = cols;
            this.MazeString = mazeString;
            drawMaze();
        }

        public void drawMaze()
        {
            //path -> geometryRect -> rect
            Rect rect = new Rect(new Point(5, 5), new Point(10, 10));
            RectangleGeometry rg = new RectangleGeometry(rect);
            Path u = new Path();
            u.Data = rg;
            u.Fill = Brushes.Black;

            u.Visibility = Visibility.Visible;
            Canvas.SetTop(u, 0);
            Canvas.SetLeft(u, 100);
            mazeCanvas.Children.Add(u);
        }
    }
}

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
            smVM.StartGame();
         }

        public void drawMaze()
        {
           // //TEMP
           // char[] mazeChars = new char[Rows * Cols];
           // for (int i = 0; i < mazeChars.Length; i++)
           // {
           //     // Random rnd = new Random(1);
           //     mazeChars[i] = '0';
           // }

           // int height = (int)mazeCanvas.Height / Rows;
           // int width =  (int)mazeCanvas.Width / Cols;
           //// char[] charArr = MazeString.ToCharArray();
           // int counter = 0;
           // for (int i = 0; i < Rows; i++)
           // {
           //     for (int j = 0; j < Cols; j++)
           //     {
           //         Rect rect = new Rect(width * j, height * i, width, height);
           //         //Rect rect = new Rect(new Point(width * j, height * i), new Point(width * j + width, height * i + height));
           //         RectangleGeometry rg = new RectangleGeometry(rect);
           //         Path u = new Path();
           //         u.Data = rg;
                   
           //             if (mazeChars[counter] == '0')
           //             {
           //                 u.Fill = Brushes.Black;
           //             }
           //             else
           //             {
           //                 u.Fill = Brushes.Aquamarine;
           //             }
           //             u.Visibility = Visibility.Visible;
           //             mazeCanvas.Children.Add(u);
           //             counter++;
                  
           //     }
           // }
        }
    }
    }

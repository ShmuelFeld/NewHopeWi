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
    /// Interaction logic for MazeUC.xaml
    /// </summary>
    public partial class MazeUC : UserControl
    {
        public int MazeRows
        {
            get
            {
                return (int)GetValue(RowsProperty);
            }
            set
            {
                SetValue(RowsProperty, value);
            }
        }

        public static readonly DependencyProperty RowsProperty = DependencyProperty.Register("MazeRows", typeof(int), typeof(MazeUC),
            new PropertyMetadata(onRowsPropertyChanged));//the 0 can be replaced with a function that whenever something changes the rows- the function will be called.

        public int MazeCols
        {
            get
            {
                return (int)GetValue(ColsProperty);
            }
            set
            {
                SetValue(ColsProperty, value);
            }
        }
        public static readonly DependencyProperty ColsProperty =
            DependencyProperty.Register("MazeCols", typeof(int), typeof(MazeUC),
            new PropertyMetadata(onColsPropertyChanged));

        public string MazeName
        {
            get
            {
                return (string)GetValue(MazeNameProperty);
            }
            set
            {
                SetValue(MazeNameProperty, value);
            }
        }
        public static readonly DependencyProperty MazeNameProperty =
            DependencyProperty.Register("MazeName", typeof(string),
                typeof(MazeUC), new PropertyMetadata(default(string)));
        public string MazeString
        {
            get
            {
                return (string)GetValue(MazeStringProperty);
            }
            set
            {
                SetValue(MazeStringProperty, value);
            }
        }
        public static readonly DependencyProperty MazeStringProperty =
            DependencyProperty.Register("MazeString", typeof(string),
                typeof(MazeUC), new PropertyMetadata(onStringPropertyChanged));

        private static void onColsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MazeUC)d).drawMaze();
        }
        private static void onRowsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MazeUC)d).drawMaze();
        }
        private static void onStringPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MazeUC)d).drawMaze();
        }
        public MazeUC()
        {
            //MazeRoot.DataContext = this;
            InitializeComponent();
            //this.Rows = rows;
            //this.Cols = cols;
            
        }

        public void drawMaze()
        {
            ////TEMP
            //char[] mazeChars = new char[Rows * Cols];
            //for (int i = 0; i < mazeChars.Length; i++)
            //{
            //    mazeChars[i] = '0';
            //}
            ////END OF TEMP
            if(MazeRows == 0 || MazeCols == 0 || MazeString == null)
            {
                return;
            }
            //TODO
            int height = 300 / MazeRows;
            int width = 300 / MazeCols;
            char[] charArr = MazeString.ToCharArray();
            
            int counter = 0;
            for (int i = 0; i < MazeRows; i++)
            {
                for (int j = 0; j < MazeCols; j++)
                {
                    Rect rect = new Rect(width * j, height * i, width, height);
                    RectangleGeometry rg = new RectangleGeometry(rect);
                    Path u = new Path();
                    u.Data = rg;

                    if (charArr[counter] == '0')
                    {
                        u.Fill = Brushes.Black;
                    }
                    else if (charArr[counter] == '1')
                    {
                        u.Fill = Brushes.White;
                    }
                    else if (charArr[counter] == '*')
                    {
                        u.Fill = Brushes.Aquamarine;
                    }
                    else if (charArr[counter] == '#')
                    {
                        u.Fill = Brushes.DarkBlue;
                    }
                    else {
                        counter++;
                        continue;
                    }
                    u.Visibility = Visibility.Visible;
                    mazeCanvas.Children.Add(u);
                    counter++;
                }
                counter += 2;
            }
        }
    }
}

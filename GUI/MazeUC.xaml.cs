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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MazeUC.xaml
    /// </summary>
    public partial class MazeUC : UserControl
    {
        public static Rectangle[,] rectanglesArr;
        public static Position currentPos;
        public static int height, width;
        public static Canvas mazeCan;
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
        public static readonly DependencyProperty RowsProperty = DependencyProperty.Register("MazeRows", typeof(int), typeof(MazeUC));
        public Position InitialPos
        {
            get
            {
                return (Position)GetValue(InitialPosProperty);
            }
            set
            {
                SetValue(InitialPosProperty, value);
            }
        }
        public static readonly DependencyProperty InitialPosProperty = DependencyProperty.Register("InitialPos", typeof(Position), typeof(MazeUC));
        public Position GoalPos
        {
            get
            {
                return (Position)GetValue(GoalPosProperty);
            }
            set
            {
                SetValue(GoalPosProperty, value);
            }
        }
        public static readonly DependencyProperty GoalPosProperty = DependencyProperty.Register("GoalPos", typeof(Position), typeof(MazeUC));
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
            DependencyProperty.Register("MazeCols", typeof(int), typeof(MazeUC));
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
                typeof(MazeUC));
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
                typeof(MazeUC));
        public string SolveString
        {
            get
            {
                return (string)GetValue(SolveStringProperty);
            }
            set
            {
                SetValue(SolveStringProperty, value);
            }
        }
        public static readonly DependencyProperty SolveStringProperty =
            DependencyProperty.Register("SolveString", typeof(string),
                typeof(MazeUC), new PropertyMetadata(onSolvePropertyChanged));

        private static void onSolvePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MazeUC)d).SolveMaze();
        }

        private void SolveMaze()
        {
            return;
        }

        public MazeUC()
        {
            InitializeComponent();
            mazeCan = mazeCanvas;
        }
        public void drawMaze()
        {
            if (MazeRows == 0 || MazeCols == 0 || MazeString == null)
            {
                return;
            }
            int rows = MazeRows;
            int cols = MazeCols;
            height = (int)mazeCanvas.Height / MazeRows;
            width = (int)mazeCanvas.Width / MazeCols;
            rectanglesArr = new Rectangle[rows, cols];
            string charArr = MazeString;
            currentPos = InitialPos;
            int counter = 0;
            for (int i = 0; i < MazeRows; i++)
            {
                for (int j = 0; j < MazeCols; j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Height = height;
                    rect.Width = width;
                    rectanglesArr[i, j] = rect;                    
                    if (charArr[counter] == '0')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
                    }
                    else if (charArr[counter] == '1')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.White);
                    }
                    else if (charArr[counter] == '*')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Aquamarine);
                    }
                    else if (charArr[counter] == '#')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkBlue);
                    }
                    else
                    {
                        counter++;
                        continue;
                    }
                    mazeCanvas.Children.Add(rectanglesArr[i, j]);
                    Canvas.SetLeft(rectanglesArr[i, j], width * j);
                    Canvas.SetTop(rectanglesArr[i, j], height * i);
                    counter++;
                }
                counter += 2;
            }
        }

        private void backToMainWindow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mazeCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += Viewbox_KeyDown;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            drawMaze();

        }

        public void Viewbox_KeyDown(object sender, KeyEventArgs e)
        {
            //if(currentPos == InitialPos)

            Position temp = currentPos;
            switch (e.Key)
            {
                case (Key.Up):
                    currentPos.Row --;
                    var rectFillColor = rectanglesArr[currentPos.Row, currentPos.Col].Fill.GetValue(SolidColorBrush.ColorProperty);
                    if ((currentPos.Row < 0) || (Colors.Black.Equals(rectFillColor)))
                    {
                        currentPos.Row++;
                        return;
                    }   
                    break;

                case (Key.Down):
                    currentPos.Row ++;
                    rectFillColor = rectanglesArr[currentPos.Row, currentPos.Col].Fill.GetValue(SolidColorBrush.ColorProperty);
                    if ((currentPos.Row >= MazeRows) || (Colors.Black.Equals(rectFillColor)))
                    {
                        currentPos.Row--;
                        return;
                    }
                    break;

                case (Key.Left):
                    currentPos.Col --;

                    rectFillColor = rectanglesArr[currentPos.Row, currentPos.Col].Fill.GetValue(SolidColorBrush.ColorProperty);
                    if ((currentPos.Col < 0) || (Colors.Black.Equals(rectFillColor)))
                    {
                        currentPos.Col++;
                        return;
                    }
                    break;

                case (Key.Right):
                    currentPos.Col ++;
                    rectFillColor = rectanglesArr[currentPos.Row, currentPos.Col].Fill.GetValue(SolidColorBrush.ColorProperty);
                    if ((currentPos.Col >= MazeCols) || (Colors.Black.Equals(rectFillColor))) 
                    {
                        currentPos.Col--;
                        return;
                    }
                    break;

                default:
                    return;

            }
            rectanglesArr[temp.Row, temp.Col].Fill = new SolidColorBrush(System.Windows.Media.Colors.White);
            Canvas.SetLeft(rectanglesArr[temp.Row, temp.Col], width * temp.Col);
            Canvas.SetTop(rectanglesArr[temp.Row, temp.Col], height * temp.Row);

            rectanglesArr[currentPos.Row, currentPos.Col].Fill = new SolidColorBrush(System.Windows.Media.Colors.Bisque);
            Canvas.SetLeft(rectanglesArr[currentPos.Row, currentPos.Col], width * currentPos.Col);
            Canvas.SetTop(rectanglesArr[currentPos.Row, currentPos.Col], height * currentPos.Row);
            if ((currentPos.Col == GoalPos.Col) && (currentPos.Row == GoalPos.Row))
            {
                SuccessWin win = new SuccessWin();
                win.Show();
            }
            e.Handled = true;
        }

       
    }
}
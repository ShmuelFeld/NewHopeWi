using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MazeUC.xaml
    /// </summary>
    public partial class MazeUC : UserControl
    {
        private Image player, dest;
        public static Rectangle[,] rectanglesArr;
        private Position currentPos;
        public static int height, width;
        public static Canvas mazeCan;
        public EventHandler MovingUp;
        public EventHandler MovingLeft;
        public EventHandler MovingRight;
        public EventHandler MovingDown;
        public Position Current
        {
            get
            {
                return this.currentPos;
            }
            set
            {
                this.currentPos = value;
            }
        }
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
            rectanglesArr[currentPos.Row, currentPos.Col].Fill = new SolidColorBrush(System.Windows.Media.Colors.White);
            currentPos = InitialPos;
            char[] solutionArr = SolveString.ToCharArray();
            for (int i = 0; i < solutionArr.Length; i++)
            {
                Application.Current.Dispatcher.Invoke(
                  DispatcherPriority.Background,
                  new Action(() =>
                  {       
                        //rectanglesArr[currentPos.Row, currentPos.Col].Fill = new SolidColorBrush(System.Windows.Media.Colors.Bisque);
                        Canvas.SetLeft(player, width * currentPos.Col);
                        Canvas.SetTop(player, height * currentPos.Row);

                        switch (solutionArr[i])
                        {
                            //left
                            case '0':
                                currentPos.Col--;
                                break;

                            //right
                            case '1':
                                currentPos.Col++;
                                break;

                            //up
                            case '2':
                                currentPos.Row--;
                                break;

                            //down
                            case '3':
                                currentPos.Row++;
                                break;
                        }
                        Thread.Sleep(300);
                    }));
            }
                
        }

        public MazeUC()
        {
            InitializeComponent();
            mazeCan = mazeCanvas;
        }
        public void drawMaze()
        {
            int rows = MazeRows;
            int cols = MazeCols;
            height = (int)mazeCanvas.Height / MazeRows;
            width = (int)mazeCanvas.Width / MazeCols;
            rectanglesArr = new Rectangle[rows, cols];
            string charArr = MazeString;
            currentPos = InitialPos;
            int counter = 0;
            bool isImage = false;
            for (int i = 0; i < MazeRows; i++)
            {
                for (int j = 0; j < MazeCols; j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Height = height;
                    rect.Width = width;
                    rectanglesArr[i, j] = rect;
                    if (charArr[counter] == '1')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
                    }
                    else if (charArr[counter] == '0')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Transparent);
                    }
                    else if (charArr[counter] == '*')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Transparent);
                        player = new Image()
                        {
                            Source = new BitmapImage(new Uri(@"C:\Users\Sharon\Desktop\imageForMaze\prince.png")),
                            Height = height,
                            Width = width,
                         };
                        mazeCanvas.Children.Add(player);
                        Canvas.SetLeft(player, width * j);
                        Canvas.SetTop(player, height * i);
                        isImage = true;
                    }                       
                       
                    
                    else if (charArr[counter] == '#')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.White);
                        dest = new Image()
                        {
                            Source = new BitmapImage(new Uri(@"C:\Users\Sharon\Desktop\imageForMaze\cinderella.jpg")),
                            Height = height,
                            Width = width,
                        };
                        mazeCanvas.Children.Add(dest);
                        Canvas.SetLeft(dest, width * j);
                        Canvas.SetTop(dest, height * i);
                        isImage = true;
                    }
                    else
                    {
                        counter++;
                        continue;
                    }
                    if (isImage == false)
                    {
                        mazeCanvas.Children.Add(rectanglesArr[i, j]);
                        Canvas.SetLeft(rectanglesArr[i, j], width * j);
                        Canvas.SetTop(rectanglesArr[i, j], height * i);
                    }
                    isImage = false;
                    counter++;
                }
                counter += 2;
            }
        }

        private void mazeCanvas_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            drawMaze();

        }
        public void Viewbox_KeyDown(object sender, KeyEventArgs e)
        {
            Position temp = currentPos;

            switch (e.Key)
            {
                case (Key.Up):
                    currentPos.Row --;
                    if (currentPos.Row < 0)
                    {
                        currentPos.Row++;
                        return;
                    }
                    var rectFillColor = rectanglesArr[currentPos.Row, currentPos.Col].Fill.GetValue(SolidColorBrush.ColorProperty);
                    if (Colors.Black.Equals(rectFillColor)){
                        currentPos.Row++;
                        return;
                    }
                    if (MovingUp != null)
                    {
                        this.MovingUp(this, new EventArgs());
                    }
                    break;

                case (Key.Down):
                    currentPos.Row ++;
                    if (currentPos.Row >= MazeRows)
                    {
                        currentPos.Row--;
                        return;
                    }
                    rectFillColor = rectanglesArr[currentPos.Row, currentPos.Col].Fill.GetValue(SolidColorBrush.ColorProperty);
                    if (Colors.Black.Equals(rectFillColor))
                    {
                        currentPos.Row--;
                        return;
                    }
                    if (MovingDown != null)
                    {
                        this.MovingDown(this, new EventArgs());
                    }
                    break;

                case (Key.Left):
                    currentPos.Col --;
                    if (currentPos.Col < 0)
                    {
                        currentPos.Col++;
                        return;
                    }
                    rectFillColor = rectanglesArr[currentPos.Row, currentPos.Col].Fill.GetValue(SolidColorBrush.ColorProperty);
                    if (Colors.Black.Equals(rectFillColor))
                    {
                        currentPos.Col++;
                        return;
                    }
                    if (MovingLeft != null)
                    {
                        this.MovingLeft(this, new EventArgs());
                    }
                    break;

                case (Key.Right):
                    currentPos.Col ++;
                    if (currentPos.Col >= MazeCols)
                    {
                        currentPos.Col--;
                        return;
                    }
                    rectFillColor = rectanglesArr[currentPos.Row, currentPos.Col].Fill.GetValue(SolidColorBrush.ColorProperty);
                    if (Colors.Black.Equals(rectFillColor))
                    {
                        currentPos.Col--;
                        return;
                    }
                    if (MovingRight != null)
                    {
                        this.MovingRight(this, new EventArgs());
                    }
                    break;
                default:
                    return;

            }
            UpdateLoc();
            if ((currentPos.Col == GoalPos.Col) && (currentPos.Row == GoalPos.Row))
            {
                SuccessWin win = new SuccessWin();
                win.Show();
            }
            e.Handled = true;

        }

        public void startOver()
        {
            currentPos = InitialPos;
            Canvas.SetLeft(player, width * currentPos.Col);
            Canvas.SetTop(player, height * currentPos.Row);
        }
        public void UpdateLoc()
        {
            Application.Current.Dispatcher.Invoke(
            DispatcherPriority.Background,
            new Action(() =>
            {
                Canvas.SetTop(player, height * currentPos.Row);
                Canvas.SetLeft(player, width * currentPos.Col);
            }));


        }
       
    }
}
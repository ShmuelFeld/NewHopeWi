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
    /// <seealso cref="System.Windows.Controls.UserControl" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MazeUC : UserControl
    {
        /// <summary>
        /// The player
        /// </summary>
        private Rectangle player, dest;
        /// <summary>
        /// The rectangles arr
        /// </summary>
        public static Rectangle[,] rectanglesArr;
        /// <summary>
        /// The current position
        /// </summary>
        private Position currentPos;
        /// <summary>
        /// The height
        /// </summary>
        public static int height, width;
        /// <summary>
        /// The maze can
        /// </summary>
        public static Canvas mazeCan;
        /// <summary>
        /// The moving up
        /// </summary>
        public EventHandler MovingUp;
        /// <summary>
        /// The moving left
        /// </summary>
        public EventHandler MovingLeft;
        /// <summary>
        /// The moving right
        /// </summary>
        public EventHandler MovingRight;
        /// <summary>
        /// The moving down
        /// </summary>
        public EventHandler MovingDown;
        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
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
        /// <summary>
        /// Gets or sets the maze rows.
        /// </summary>
        /// <value>
        /// The maze rows.
        /// </value>
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
        /// <summary>
        /// The rows property
        /// </summary>
        public static readonly DependencyProperty RowsProperty = DependencyProperty.Register("MazeRows", typeof(int), typeof(MazeUC));
        /// <summary>
        /// Gets or sets the initial position.
        /// </summary>
        /// <value>
        /// The initial position.
        /// </value>
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
        /// <summary>
        /// The initial position property
        /// </summary>
        public static readonly DependencyProperty InitialPosProperty = DependencyProperty.Register("InitialPos", typeof(Position), typeof(MazeUC));
        /// <summary>
        /// Gets or sets the goal position.
        /// </summary>
        /// <value>
        /// The goal position.
        /// </value>
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
        /// <summary>
        /// The goal position property
        /// </summary>
        public static readonly DependencyProperty GoalPosProperty = DependencyProperty.Register("GoalPos", typeof(Position), typeof(MazeUC));
        /// <summary>
        /// Gets or sets the maze cols.
        /// </summary>
        /// <value>
        /// The maze cols.
        /// </value>
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
        /// <summary>
        /// The cols property
        /// </summary>
        public static readonly DependencyProperty ColsProperty =
            DependencyProperty.Register("MazeCols", typeof(int), typeof(MazeUC));
        /// <summary>
        /// Gets or sets the name of the maze.
        /// </summary>
        /// <value>
        /// The name of the maze.
        /// </value>
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
        /// <summary>
        /// The maze name property
        /// </summary>
        public static readonly DependencyProperty MazeNameProperty =
            DependencyProperty.Register("MazeName", typeof(string),
                typeof(MazeUC));
        /// <summary>
        /// Gets or sets the maze string.
        /// </summary>
        /// <value>
        /// The maze string.
        /// </value>
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
        /// <summary>
        /// The maze string property
        /// </summary>
        public static readonly DependencyProperty MazeStringProperty =
            DependencyProperty.Register("MazeString", typeof(string),
                typeof(MazeUC));
        /// <summary>
        /// Gets or sets the solve string.
        /// </summary>
        /// <value>
        /// The solve string.
        /// </value>
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
        /// <summary>
        /// The solve string property
        /// </summary>
        public static readonly DependencyProperty SolveStringProperty =
            DependencyProperty.Register("SolveString", typeof(string),
                typeof(MazeUC), new PropertyMetadata(onSolvePropertyChanged));

        /// <summary>
        /// Ons the solve property changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void onSolvePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MazeUC)d).SolveMaze();
        }

        /// <summary>
        /// Solves the maze.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="MazeUC"/> class.
        /// </summary>
        public MazeUC()
        {
            InitializeComponent();
            mazeCan = mazeCanvas;
        }
        /// <summary>
        /// Draws the maze.
        /// </summary>
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
                        player = rectanglesArr[i, j];
                        ImageBrush playerImg = new ImageBrush();
                        playerImg.ImageSource = new BitmapImage(new Uri(@"resources/prince.png", UriKind.Relative));
                        player.Fill = playerImg;
                        mazeCanvas.Children.Add(player);
                        Canvas.SetLeft(player, width * j);
                        Canvas.SetTop(player, height * i);
                        isImage = true;
                    }                       
                       
                    
                    else if (charArr[counter] == '#')
                    {
                        dest = rectanglesArr[i, j];
                        ImageBrush playerImg = new ImageBrush();
                        playerImg.ImageSource = new BitmapImage(new Uri(@"resources\cinderella.jpg", UriKind.Relative));
                        dest.Fill = playerImg;
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
        /// <summary>
        /// Handles the Loaded event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            drawMaze();

        }
        /// <summary>
        /// Handles the KeyDown event of the Viewbox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Starts the over.
        /// </summary>
        public void startOver()
        {
            currentPos = InitialPos;
            Canvas.SetLeft(player, width * currentPos.Col);
            Canvas.SetTop(player, height * currentPos.Row);
        }
        /// <summary>
        /// Updates the loc.
        /// </summary>
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
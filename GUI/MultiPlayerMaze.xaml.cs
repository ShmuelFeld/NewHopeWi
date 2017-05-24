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
using System.Windows.Threading;

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
            MyBoard.MovingUp += new EventHandler(GoUp);
            MyBoard.MovingDown += new EventHandler(GoDown);
            MyBoard.MovingLeft += new EventHandler(GoLeft);
            MyBoard.MovingRight += new EventHandler(GoRight);
            mpVM.ChangeOtherLoc += new EventHandler(moveOpponent);
        }

        private void moveOpponent(object sender, EventArgs e)
        {
            Position temp;
            switch (mpVM.Direction)
            {
               
                case "up":
                    //Application.Current.Dispatcher.Invoke(
                    //DispatcherPriority.Background,
                    //new Action(() =>
                    //this.OtherBoard.Viewbox_KeyDown(this,
                    //new KeyEventArgs(
                    //Keyboard.PrimaryDevice,
                    //PresentationSource.FromVisual((Visual)Keyboard.FocusedElement), 0, Key.Up))));
                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(--temp.Row, temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                case "down":
                    //Application.Current.Dispatcher.Invoke(
                    //DispatcherPriority.Background,
                    //new Action(() =>
                    //this.OtherBoard.Viewbox_KeyDown(this,
                    //new KeyEventArgs(
                    //Keyboard.PrimaryDevice,
                    //PresentationSource.FromVisual((Visual)Keyboard.FocusedElement), 0, Key.Down))));

                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(++temp.Row, temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                case "left":
                    //Application.Current.Dispatcher.Invoke(
                    //DispatcherPriority.Background,
                    //new Action(() =>
                    //this.OtherBoard.Viewbox_KeyDown(this,
                    //new KeyEventArgs(
                    //Keyboard.PrimaryDevice,
                    //PresentationSource.FromVisual((Visual)Keyboard.FocusedElement), 0, Key.Left))));
                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(temp.Row, --temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                case "right":
                    //Application.Current.Dispatcher.Invoke(
                    //DispatcherPriority.Background,
                    //new Action(() =>
                    //this.OtherBoard.Viewbox_KeyDown(this,
                    //new KeyEventArgs(
                    //Keyboard.PrimaryDevice,
                    //PresentationSource.FromVisual((Visual)Keyboard.FocusedElement), 0, Key.Right))));
                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(temp.Row, ++temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                default:
                    break;
            }
        }

        private void GoRight(object sender, EventArgs e)
        {
            mpVM.MovementNotify("right");
        }

        private void GoLeft(object sender, EventArgs e)
        {
            mpVM.MovementNotify("left");
        }

        private void GoDown(object sender, EventArgs e)
        {
            mpVM.MovementNotify("down");
        }

        private void GoUp(object sender, EventArgs e)
        {
            mpVM.MovementNotify("up");
        }

        private void BackToMainWin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}

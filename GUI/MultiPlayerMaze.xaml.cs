using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MultiPlayerMaze.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MultiPlayerMaze : Window
    {
        /// <summary>
        /// Gets or sets the maze rows.
        /// </summary>
        /// <value>
        /// The maze rows.
        /// </value>
        public int MazeRows { get; set; }
        /// <summary>
        /// Gets or sets the maze cols.
        /// </summary>
        /// <value>
        /// The maze cols.
        /// </value>
        public int MazeCols { get; set; }
        /// <summary>
        /// Gets or sets the maze string.
        /// </summary>
        /// <value>
        /// The maze string.
        /// </value>
        public string MazeString { get; set; }
        /// <summary>
        /// Gets or sets the initial position.
        /// </summary>
        /// <value>
        /// The initial position.
        /// </value>
        public Position InitialPos { get; set; }
        /// <summary>
        /// Gets or sets the goal position.
        /// </summary>
        /// <value>
        /// The goal position.
        /// </value>
        public Position GoalPos { get; set; }
        /// <summary>
        /// The mp vm
        /// </summary>
        private MultiPlayerMazeVM mpVM;
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayerMaze"/> class.
        /// </summary>
        /// <param name="str">The string.</param>
        public MultiPlayerMaze(string str)
        {
            InitializeComponent();
            mpVM = new MultiPlayerMazeVM(str);
            this.DataContext = mpVM;
            this.KeyDown += MyBoard.Viewbox_KeyDown;
            MyBoard.MovingUp += new EventHandler(GoUp);
            MyBoard.MovingDown += new EventHandler(GoDown);
            MyBoard.MovingLeft += new EventHandler(GoLeft);
            MyBoard.MovingRight += new EventHandler(GoRight);
            mpVM.ChangeOtherLoc += new EventHandler(MoveOpponent);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayerMaze"/> class.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="name">The name.</param>
        public MultiPlayerMaze(int rows, int cols, string name)
        {
            InitializeComponent();
            mpVM = new MultiPlayerMazeVM(rows, cols, name);
            this.DataContext = mpVM;
            this.KeyDown += MyBoard.Viewbox_KeyDown;
            MyBoard.MovingUp += new EventHandler(GoUp);
            MyBoard.MovingDown += new EventHandler(GoDown);
            MyBoard.MovingLeft += new EventHandler(GoLeft);
            MyBoard.MovingRight += new EventHandler(GoRight);
            mpVM.ChangeOtherLoc += new EventHandler(MoveOpponent);
            mpVM.CloseEv += new EventHandler(CloseWin);
            this.Closing += MultiPlayerMaze_Closing;
        }
        /// <summary>
        /// Closes the win.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CloseWin(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(
           DispatcherPriority.Background,
           new Action(() =>
           {
               string message = "The other player has left the game, you will be moved to main window";
               string caption = "warning";
               MessageBoxButtons buttons = MessageBoxButtons.OK;
               DialogResult result;

               result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);

               if (result == System.Windows.Forms.DialogResult.OK)
               {
                   this.Closing -= MultiPlayerMaze_Closing;
                   MainWindow m = new MainWindow();
                   m.Show();
                   this.Close();
               }               
           }));         

        }


        /// <summary>
        /// Moves the opponent.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MoveOpponent(object sender, EventArgs e)
        {
            Position temp;
            switch (mpVM.Direction)
            {
               
                case "up":
                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(--temp.Row, temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                case "down":
                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(++temp.Row, temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                case "left":
                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(temp.Row, --temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                case "right":
                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(temp.Row, ++temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Goes the right.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GoRight(object sender, EventArgs e)
        {
            mpVM.MovementNotify("right");
        }

        /// <summary>
        /// Goes the left.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GoLeft(object sender, EventArgs e)
        {
            mpVM.MovementNotify("left");
        }

        /// <summary>
        /// Goes down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GoDown(object sender, EventArgs e)
        {
            mpVM.MovementNotify("down");
        }

        /// <summary>
        /// Goes up.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GoUp(object sender, EventArgs e)
        {
            mpVM.MovementNotify("up");
        }

        /// <summary>
        /// Handles the Click event of the BackToMainWin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BackToMainWin_Click(object sender, RoutedEventArgs e)
        {
            string message = "are you sure?";
            string caption = "warning!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                mpVM.CloseSelf();
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }        
            
        }

        /// <summary>
        /// Handles the Closing event of the MultiPlayerMaze control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void MultiPlayerMaze_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mpVM.CloseSelf();
            MainWindow mw = new MainWindow();
            mw.Show();
            
        }
    }
}

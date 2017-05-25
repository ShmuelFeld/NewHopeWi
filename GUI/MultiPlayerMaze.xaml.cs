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
    public partial class MultiPlayerMaze : Window
    {
        public int MazeRows { get; set; }
        public int MazeCols { get; set; }
        public string MazeString { get; set; }
        public Position InitialPos { get; set; }
        public Position GoalPos { get; set; }
        private MultiPlayerMazeVM mpVM;
        // cancel the control box of the window
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void singlePlayerMazeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
        // public EventHandler CloseEve;

        public MultiPlayerMaze(string kind)
        {
            InitializeComponent();
            mpVM = new MultiPlayerMazeVM(kind);
            if (ConnectionError.isError)
            {
                return;
            }
            this.DataContext = mpVM;
            this.KeyDown += MyBoard.Viewbox_KeyDown;
            MyBoard.MovingUp += new EventHandler(GoUp);
            MyBoard.MovingDown += new EventHandler(GoDown);
            MyBoard.MovingLeft += new EventHandler(GoLeft);
            MyBoard.MovingRight += new EventHandler(GoRight);
            mpVM.ChangeOtherLoc += new EventHandler(moveOpponent);
            mpVM.CloseEv += new EventHandler(CloseWin);
            //MyBoard.Close += new EventHandler(CloseOther);
        }

        private void CloseWin(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(
           DispatcherPriority.Background,
           new Action(() =>
           {                      
               MainWindow mw = new MainWindow();
               mw.Show();
               this.Close();
           }));
          

        }

        private void moveOpponent(object sender, EventArgs e)
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
            string message = "are you sure?";
            string caption = "Error Detected in Input";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
                mpVM.CloseSelf();
            }          
            
        }
    }
}

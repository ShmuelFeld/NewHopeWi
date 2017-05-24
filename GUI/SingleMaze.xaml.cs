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
        public Position InitialPos { get; set; }
        public Position GoalPos { get; set; }
        public string SolveString { get; set; }

        // cancel the control box of the window
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private SingleMazeVM smVM;

        public SingleMaze()
        {
            smVM = new SingleMazeVM();
            if (ConnectionError.isError)
            {
                return;
            }
            InitializeComponent();
            
            this.DataContext = smVM;
            this.KeyDown += userControl.Viewbox_KeyDown;
        }

        private void MainWin_Click(object sender, RoutedEventArgs e)
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
            }

        }

        private void solve_Click(object sender, RoutedEventArgs e)
        {
            smVM.SolveMaze();
            userControl.SolveString = smVM.SolveVM;      
        }

        private void startOver_Click(object sender, RoutedEventArgs e)
        {
            string message = "are you sure?";
            string caption = "Error Detected in Input";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                userControl.startOver();    
            }
                    
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
    }
}
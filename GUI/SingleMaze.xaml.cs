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
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class SingleMaze : Window
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
        /// Gets or sets the solve string.
        /// </summary>
        /// <value>
        /// The solve string.
        /// </value>
        public string SolveString { get; set; }

        /// <summary>
        /// The sm vm
        /// </summary>
        private SingleMazeVM smVM;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleMaze"/> class.
        /// </summary>
        public SingleMaze(int rows, int cols, string name)
        {
            InitializeComponent();
            smVM = new SingleMazeVM(rows, cols, name);
            this.DataContext = smVM;
            this.KeyDown += userControl.Viewbox_KeyDown;
        }

        /// <summary>
        /// Handles the Click event of the MainWin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void MainWin_Click(object sender, RoutedEventArgs e)
        {
            BackToMain();
        }

        /// <summary>
        /// Backs to main.
        /// </summary>
        private void BackToMain()
        {
            string message = "are you sure?";
            string caption = "warning!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
           
            
        }

        /// <summary>
        /// Handles the Click event of the solve control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void solve_Click(object sender, RoutedEventArgs e)
        {
            smVM.SolveMaze();
            userControl.SolveString = smVM.SolveVM;      
        }

        /// <summary>
        /// Handles the Click event of the startOver control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
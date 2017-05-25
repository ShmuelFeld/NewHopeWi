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
    /// Interaction logic for MultiPlayer.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MultiPlayer : Window
    {
        /// <summary>
        /// The MPVM
        /// </summary>
        private MultiPlayerVM mpvm;
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayer"/> class.
        /// </summary>
        public MultiPlayer()
        {
            InitializeComponent();
            MultiPlayerModel model = new MultiPlayerModel();
            mpvm = new MultiPlayerVM(model);
            if (ConnectionError.isError)
            {
                return;
            }
            SUC.ColsValue.Text = Properties.Settings.Default.MazeCols.ToString();
            SUC.RowsValue.Text = Properties.Settings.Default.MazeRows.ToString();
            SUC.NameValue.Text = Properties.Settings.Default.MazeName;
            this.DataContext = mpvm;
            InsertToComboBox(mpvm.ListOfGames);
            ListOfGames.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the JoinGame control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void JoinGame_Click(object sender, RoutedEventArgs e)
        {
            mpvm.MazeName = ListOfGames.Text;
            if (mpvm.MazeName == "")
            {
                return;
            }
            MultiPlayerMaze mpm = new MultiPlayerMaze(mpvm.MazeName);
            if (ConnectionError.isError)
            {
                MainWindow w = new MainWindow();
                w.Show();
                this.Close();
                return;
            }
            mpm.Show();
            this.Close();
        }
        /// <summary>
        /// Handles the Click event of the StartGame control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            mpvm.MazeCols = int.Parse(SUC.ColsValue.Text);
            mpvm.MazeRows = int.Parse(SUC.RowsValue.Text);
            mpvm.MazeName = SUC.NameValue.Text;

            if (!NameExist(mpvm.MazeName))
            {
                WaitingWin w = new WaitingWin();
                w.Show();
                MultiPlayerMaze mpm = new MultiPlayerMaze(mpvm.MazeRows, mpvm.MazeCols, mpvm.MazeName);
                w.Close();
                mpm.Show();
                this.Close();
            }
             else if (ConnectionError.isError)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
                return;
            }
            else
            {
                ExistPopUp epp = new ExistPopUp();
                epp.Show();
                this.Close();
            }

        }
        /// <summary>
        /// Inserts to ComboBox.
        /// </summary>
        /// <param name="list">The list.</param>
        private void InsertToComboBox(List<string> list)
        {
            foreach (string item in list)
            {
                ListOfGames.Items.Add(item);
            }
        }
        private bool NameExist(string str)
        {
            foreach (string item in mpvm.ListOfGames)
            {
                if(item.Equals(str))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// refresh the combe box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            mpvm.RefreshGameList();
            InsertToComboBox(mpvm.ListOfGames);
            ListOfGames.SelectedIndex = 0;
        }
    }
}

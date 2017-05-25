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
    public partial class MultiPlayer : Window
    {
        private MultiPlayerVM mpvm;
        public MultiPlayer()
        {
            InitializeComponent();
            MultiPlayerModel model = new MultiPlayerModel();
            mpvm = new MultiPlayerVM(model);
            SUC.ColsValue.Text = Properties.Settings.Default.MazeCols.ToString();
            SUC.RowsValue.Text = Properties.Settings.Default.MazeRows.ToString();
            SUC.NameValue.Text = Properties.Settings.Default.MazeName;
            this.DataContext = mpvm;
            InsertToComboBox(mpvm.ListOfGames);
            ListOfGames.SelectedIndex = 0;
        }

        private void JoinGame_Click(object sender, RoutedEventArgs e)
        {
            mpvm.MazeName = ListOfGames.Text;
            MultiPlayerMaze mpm = new MultiPlayerMaze(mpvm.MazeName);
            mpm.Show();
            this.Close();
        }
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
            else
            {
                ExistPopUp epp = new ExistPopUp();
                epp.Show();
                this.Close();
            }
        }
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

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            mpvm.RefreshGameList();
            InsertToComboBox(mpvm.ListOfGames);
            ListOfGames.SelectedIndex = 0;
        }
    }
}

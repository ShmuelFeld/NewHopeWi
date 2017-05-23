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
            SUC.ColsValue.Text = Properties.Settings.Default.MazeCols.ToString();
            SUC.RowsValue.Text = Properties.Settings.Default.MazeRows.ToString();
            mpvm = new MultiPlayerVM(model);
            this.DataContext = mpvm;
            InsertToComboBox(mpvm.ListOfGames);
        }

        private void JoinGame_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            mpvm.MazeCols = int.Parse(SUC.ColsValue.Text);
            mpvm.MazeRows = int.Parse(SUC.RowsValue.Text);
            mpvm.MazeName = SUC.NameValue.Text;
            waitLabel.Visibility = Visibility.Visible;
            MultiPlayerMaze mpm = new MultiPlayerMaze();
            waitLabel.Visibility = Visibility.Hidden;
            mpm.Show();
            this.Close();
        }
        private void InsertToComboBox(List<string> list)
        {
            foreach (string item in list)
            {
                ListOfGames.Items.Add(item);
            }
        }

    }
}

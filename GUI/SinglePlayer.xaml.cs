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
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        private SinglePlayerVM spvm;
        public SinglePlayer()
        {
            InitializeComponent();
            ISinglePlayerModel model = new ApplicationSinglePlayerModel();
            spvm = new SinglePlayerVM(model);
            SUC.ColsValue.Text = Properties.Settings.Default.MazeCols.ToString();
            SUC.RowsValue.Text = Properties.Settings.Default.MazeRows.ToString();
            SUC.NameValue.Text = Properties.Settings.Default.MazeName;
            this.DataContext = spvm;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            spvm.MazeCols = int.Parse(SUC.ColsValue.Text);
            spvm.MazeRows = int.Parse(SUC.RowsValue.Text);
            spvm.MazeName = SUC.NameValue.Text;
            SingleMaze m = new SingleMaze(spvm.MazeRows, spvm.MazeCols, spvm.MazeName);
            m.Show();
            this.Close();
        }
    }
}
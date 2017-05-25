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
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class SinglePlayer : Window
    {
        /// <summary>
        /// The SPVM
        /// </summary>
        private SinglePlayerVM spvm;
        /// <summary>
        /// Initializes a new instance of the <see cref="SinglePlayer"/> class.
        /// </summary>
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

        /// <summary>
        /// Handles the Click event of the btnStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            spvm.MazeCols = int.Parse(SUC.ColsValue.Text);
            spvm.MazeRows = int.Parse(SUC.RowsValue.Text);
            spvm.MazeName = SUC.NameValue.Text;
            SingleMaze m = new SingleMaze(spvm.MazeRows, spvm.MazeCols, spvm.MazeName);
            if (ConnectionError.isError)
            {
                MainWindow w = new MainWindow();
                w.Show();
                this.Close();
                return;
            }
            m.Show();
            this.Close();
        }
    }
}
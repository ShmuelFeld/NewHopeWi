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
    /// Interaction logic for WinConfirm.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class WinConfirm : Window
    {
        /// <summary>
        /// The sm
        /// </summary>
        private SingleMaze sm;
        /// <summary>
        /// Initializes a new instance of the <see cref="WinConfirm"/> class.
        /// </summary>
        /// <param name="s">The s.</param>
        public WinConfirm(SingleMaze s)
        {
            InitializeComponent();
            this.sm = s;
        }

        /// <summary>
        /// Handles the Click event of the yes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            sm.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the no control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void no_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

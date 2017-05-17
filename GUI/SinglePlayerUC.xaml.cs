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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for SinglePlayerUC.xaml
    /// </summary>
    public partial class SinglePlayerUC : UserControl
    {
        public string MazeName
        {
            get
            {
                return (string)GetValue(MazeNameProperty);
            }
            set
            {
                SetValue(MazeNameProperty, value);
            }
        }
        public static readonly DependencyProperty MazeNameProperty =
    DependencyProperty.Register("MazeName", typeof(string),
      typeof(SinglePlayerUC), new PropertyMetadata(""));
        public SinglePlayerUC()
        {
            InitializeComponent();
            //this.DataContext = this;
            //LayoutRoot.DataContext = this;
        }
    }
}

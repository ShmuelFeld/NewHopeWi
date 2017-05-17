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
    /// Interaction logic for BasicMPUC.xaml
    /// </summary>
    public partial class BasicMPUC : UserControl
    {
        public BasicMPUC()
        {
            InitializeComponent();
            MPUCRoot.DataContext = this;
        }
        public String Label
        {
            get { return (String)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string),
              typeof(BasicMPUC));
        public object ListOfGames
        {
            get { return (object)GetValue(ListOfGamesProperty); }
            set { SetValue(ListOfGamesProperty, value); }
        }
        public static readonly DependencyProperty ListOfGamesProperty =
            DependencyProperty.Register("ListOfGames", typeof(string),
              typeof(BasicMPUC));
    }
}

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
    /// Interaction logic for BasicUC.xaml
    /// </summary>
    public partial class BasicUC : UserControl
    {
        public BasicUC()
        {
            InitializeComponent();
            //this.DataContext = this;
            LayoutRoot.DataContext = this;
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
              typeof(BasicUC));

        public string MazeNameProperty
        {
            get { return (string)GetValue(MazeNamePropertyproperty); }
            set { SetValue(MazeNamePropertyproperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty MazeNamePropertyproperty =
            DependencyProperty.Register("MazeNameProperty", typeof(string),
              typeof(BasicUC), new UIPropertyMetadata(string.Empty));


        public String Label_1
        {
            get { return (String)GetValue(Label_1Property); }
            set { SetValue(Label_1Property, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty Label_1Property =
            DependencyProperty.Register("Label_1", typeof(string),
              typeof(BasicUC));

        public int MazeRowsProperty
        {
            get { return (int)GetValue(MazeRowsPropertyProperty); }
            set { SetValue(MazeRowsPropertyProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty MazeRowsPropertyProperty =
            DependencyProperty.Register("MazeRowsProperty", typeof(int),
              typeof(BasicUC));
        public String Label_2
        {
            get { return (String)GetValue(Label_2Property); }
            set { SetValue(Label_2Property, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty Label_2Property =
            DependencyProperty.Register("Label_2", typeof(string),
              typeof(BasicUC));

        public int MazeColsProperty
        {
            get { return (int)GetValue(MazeColsPropertyProperty); }
            set { SetValue(MazeColsPropertyProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty MazeColsPropertyProperty =
            DependencyProperty.Register("MazeColsProperty", typeof(int),
              typeof(BasicUC));
    }
}

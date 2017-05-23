
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class MultiPlayerVM : ViewModel
    {
        private MultiPlayerModel model;
        public MultiPlayerVM(MultiPlayerModel model)
        {
            this.model = model;
            list = new List<string>();
            model.connect("list");
        }

        private List<string> list;
        public List<string> ListOfGames
        {
            get
            {
                return model.ListOfGames;
            }
            set
            {
                list = value;
                NotifyPropertyChanged("ListOfGames");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public new void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public int MazeRows
        {
            get { return model.MazeRows; }
            set
            {
                model.MazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }
        public int MazeCols
        {
            get { return model.MazeCols; }
            set
            {
                model.MazeCols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }
        public string MazeName
        {
            get { return model.MazeName; }
            set
            {
                model.MazeName = value;
                NotifyPropertyChanged("MazeName");
            }
        }
    }
}
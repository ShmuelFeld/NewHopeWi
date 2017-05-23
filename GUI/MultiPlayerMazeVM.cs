using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class MultiPlayerMazeVM : ViewModel
    {
        private MultiPlayerMazeModel model;
        public Maze MazeVM
        {
            get { return model.MazeVM; }
            set
            {
                model.MazeVM = value;
                NotifyPropertyChanged("MazeVM");
            }
        }
        private string kind;
        public MultiPlayerMazeVM(string kind)
        {
            this.model = new MultiPlayerMazeModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) { NotifyPropertyChanged(e.PropertyName); };
            if (kind == "start")
            {
                StartGame();
            }
            else
            {
                JoinGame();
            }
        }

        public void StartGame()
        {
            string command = "start ";
            command += Properties.Settings.Default.MazeName + " " + Properties.Settings.Default.MazeRows + " " + Properties.Settings.Default.MazeCols;
            model.connect(command);
        }

        public void JoinGame()
        {
            string command = "join ";
            command += Properties.Settings.Default.MazeName;
            model.connect(command);
        }
        public void MovementNotify(string direction)
        {
            string command = "play ";
            command += direction;
            model.connect(command);
        }
    }
}

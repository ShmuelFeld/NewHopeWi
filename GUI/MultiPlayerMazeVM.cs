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
        private string direction;
        public EventHandler ChangeOtherLoc;
        public int MazeRows
        {
            get
            {
                return this.rows;
            }
            set
            {
                this.rows = value;
            }
        }
        public int MazeCols
        {
            get
            {
                return this.cols;
            }
            set
            {
                this.cols = value;
            }
        }
        public string MazeName
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Direction {
            get { return this.direction; }
            set
            {
                this.direction = value;
                if (ChangeOtherLoc != null)
                {
                    this.ChangeOtherLoc(this, new EventArgs());
                }

            }
        }
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
        private int rows;
        private int cols;
        private string name;
        public EventHandler Name;
        public MultiPlayerMazeVM(string name)
        {
            MazeName = name;
            this.model = new MultiPlayerMazeModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) { NotifyPropertyChanged(e.PropertyName); };
            JoinGame();
            model.Move += new EventHandler(MoveVM);
        }
        public MultiPlayerMazeVM(int rows, int cols, string name)
        {
            MazeCols = cols;
            MazeName = name;
            MazeRows = rows;
            this.model = new MultiPlayerMazeModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) { NotifyPropertyChanged(e.PropertyName); };
            StartGame();
            model.Move += new EventHandler(MoveVM);
        }
        private void MoveVM(object sender, EventArgs e)
        {
            Direction = model.Movement;
        }

        public void StartGame()
        {
            string command = "start ";
            command += MazeName + " " + MazeRows + " " + MazeCols;
            model.connect(command);
        }

        public void JoinGame()
        {
            string command = "join ";
            command += MazeName;
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

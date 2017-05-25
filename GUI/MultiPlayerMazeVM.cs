using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GUI.ViewModel" />
    class MultiPlayerMazeVM : ViewModel
    {
        /// <summary>
        /// The model
        /// </summary>
        private MultiPlayerMazeModel model;
        /// <summary>
        /// The direction
        /// </summary>
        private string direction;
        /// <summary>
        /// The change other loc
        /// </summary>
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

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>

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
        /// <summary>
        /// Gets or sets the maze vm.
        /// </summary>
        /// <value>
        /// The maze vm.
        /// </value>
        public Maze MazeVM
        {
            get { return model.MazeVM; }
            set
            {
                model.MazeVM = value;
                NotifyPropertyChanged("MazeVM");
            }
        }
        /// <summary>
        /// The kind
        /// </summary>
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
            model.CloseEve += new EventHandler(CloseVM);
        }
        /// <summary>
        /// The close ev
        /// </summary>
        public EventHandler CloseEv;
        /// <summary>
        /// Closes the vm.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void CloseVM(object sender, EventArgs e)
        {
            if (CloseEv != null)
            {
                this.CloseEv(this, new EventArgs());
            }
        }
        /// <summary>
        /// Closes the self.
        /// </summary>
        public void CloseSelf()
        {
            model.connect("close");
        }
        /// <summary>
        /// Moves the vm.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MoveVM(object sender, EventArgs e)
        {
            Direction = model.Movement;
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            string command = "start ";
            command += MazeName + " " + MazeRows + " " + MazeCols;
            model.connect(command);
        }

        /// <summary>
        /// Joins the game.
        /// </summary>
        public void JoinGame()
        {
            string command = "join ";
            command += MazeName;
            model.connect(command);
        }
        /// <summary>
        /// Movements the notify.
        /// </summary>
        /// <param name="direction">The direction.</param>
        public void MovementNotify(string direction)
        {
            string command = "play ";
            command += direction;
            model.connect(command);
        }
    }
}

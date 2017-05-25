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
        /// <summary>
        /// property for number of rows in the maze
        /// </summary>
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
        /// <summary>
        /// property for number of columns in the maze
        /// </summary>
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
        /// <summary>
        /// /// property for the name of the maze
        /// </summary>
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
        /// <summary>
        /// the rows
        /// </summary>
        private int rows;
        /// <summary>
        /// the columns
        /// </summary>
        private int cols;
        /// <summary>
        /// The name
        /// </summary>
        private string name;
        /// <summary>
        /// The nameEvent
        /// </summary>
        public EventHandler Name;
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayerMazeVM"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public MultiPlayerMazeVM(string name)
        {
            MazeName = name;
            this.model = new MultiPlayerMazeModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) { NotifyPropertyChanged(e.PropertyName); };
            JoinGame();
            model.Move += new EventHandler(MoveVM);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayerMazeVM"/> class.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="name">The name.</param>
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
            model.sendToServer("close");
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
            model.sendToServer(command);
        }

        /// <summary>
        /// Joins the game.
        /// </summary>
        public void JoinGame()
        {
            string command = "join ";
            command += MazeName;
            model.sendToServer(command);
        }
        /// <summary>
        /// Movements the notify.
        /// </summary>
        /// <param name="direction">The direction.</param>
        public void MovementNotify(string direction)
        {
            string command = "play ";
            command += direction;
            model.sendToServer(command);
        }
    }
}

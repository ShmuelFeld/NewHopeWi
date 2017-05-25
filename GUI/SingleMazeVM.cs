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
    class SingleMazeVM : ViewModel
    {

        private int rows;
        private int cols;
        private string name;
        private SingleMazeModel model;
        public int MazeRows {
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
        /// Gets or sets the solve vm.
        /// </summary>
        /// <value>
        /// The solve vm.
        /// </value>
        public string SolveVM
        {
            get { return model.SolveVM; }
            set
            {
                model.SolveVM = value;
                NotifyPropertyChanged("SolveVM");
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleMazeVM"/> class.
        /// </summary>
        public SingleMazeVM(int rows, int cols, string name)
        {
            this.model = new SingleMazeModel();
            MazeCols = cols;
            MazeRows = rows;
            MazeName = name;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) { NotifyPropertyChanged(e.PropertyName); };
            StartGame();
        }


        /// <summary>
        /// Starts the game.
        /// </summary>

        public void StartGame()
        {
            string command = "generate ";
            command += MazeName + " " + MazeRows + " " + MazeCols;
            model.sendToServer(command);
            
        }
        /// <summary>
        /// Solves the maze.
        /// </summary>
        public void SolveMaze()
        {
            string command = "solve ";
            command += MazeName + " " + Properties.Settings.Default.SearchAlgorithm;
            model.sendToServer(command);
        }
       
    }
}
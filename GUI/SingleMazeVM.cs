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

        /// <summary>
        /// The model
        /// </summary>
        private SingleMazeModel model;

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
        public SingleMazeVM()
        {
            this.model = new SingleMazeModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) { NotifyPropertyChanged(e.PropertyName); };
            StartGame();
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            string command = "generate ";
            command += Properties.Settings.Default.MazeName + " " + Properties.Settings.Default.MazeRows + " " + Properties.Settings.Default.MazeCols;
            model.connect(command);
            
        }
        /// <summary>
        /// Solves the maze.
        /// </summary>
        public void SolveMaze()
        {
            string command = "solve ";
            command += Properties.Settings.Default.MazeName + " " + Properties.Settings.Default.SearchAlgorithm;
            model.connect(command);
        }
       
    }
}
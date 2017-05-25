using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GUI.ViewModel" />
    class SinglePlayerVM : ViewModel
    {
        /// <summary>
        /// The model
        /// </summary>
        private ISinglePlayerModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="SinglePlayerVM"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public SinglePlayerVM(ISinglePlayerModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// Gets or sets the maze rows.
        /// </summary>
        /// <value>
        /// The maze rows.
        /// </value>
        public int MazeRows
        {
            get { return model.MazeRows; }
            set
            {
                model.MazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }
        /// <summary>
        /// Gets or sets the maze cols.
        /// </summary>
        /// <value>
        /// The maze cols.
        /// </value>
        public int MazeCols
        {
            get { return model.MazeCols; }
            set
            {
                model.MazeCols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }
        /// <summary>
        /// Gets or sets the name of the maze.
        /// </summary>
        /// <value>
        /// The name of the maze.
        /// </value>
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
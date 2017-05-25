
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
    class MultiPlayerVM : ViewModel
    {
        /// <summary>
        /// The model
        /// </summary>
        private MultiPlayerModel model;
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayerVM"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public MultiPlayerVM(MultiPlayerModel model)
        {
            this.model = model;
            list = new List<string>();
            RefreshGameList();
        }

        /// <summary>
        /// The list
        /// </summary>
        private List<string> list;
        /// <summary>
        /// Gets or sets the list of games.
        /// </summary>
        /// <value>
        /// The list of games.
        /// </value>
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
        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        public new void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
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
        /// <summary>
        /// Refreshes the game list.
        /// </summary>
        public void RefreshGameList()
        {
            model.sendToServer("list");
        }
    }
}
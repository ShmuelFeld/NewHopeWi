using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
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
        public Maze MazeVM
        {
            get { return model.MazeVM; }
            set
            {
                model.MazeVM = value;
                NotifyPropertyChanged("MazeVM");
            }
        }
        public string SolveVM
        {
            get { return model.SolveVM; }
            set
            {
                model.SolveVM = value;
                NotifyPropertyChanged("SolveVM");
            }
        }
        public SingleMazeVM()
        {
            this.model = new SingleMazeModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) { NotifyPropertyChanged(e.PropertyName); };
            StartGame();
        }
        public SingleMazeVM(int rows, int cols, string name)
        {
            this.model = new SingleMazeModel();
            MazeCols = cols;
            MazeRows = rows;
            MazeName = name;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) { NotifyPropertyChanged(e.PropertyName); };
            StartGame();
        }
        public void StartGame()
        {
            string command = "generate ";
            command += MazeName + " " + MazeRows + " " + MazeCols;
            model.connect(command);
        }
        public void SolveMaze()
        {
            string command = "solve ";
            command += MazeName + " " + Properties.Settings.Default.SearchAlgorithm;
            model.connect(command);
        }
       
    }
}
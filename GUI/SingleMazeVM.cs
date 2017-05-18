﻿using MazeLib;
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

        private SingleMazeModel model;
        public Maze MazeVM
        {
            get { return model.MazeVM; }
            set {
                model.MazeVM = value;
                NotifyPropertyChanged("MazeVM");
            }
        }

        public SingleMazeVM()
        {
           //...... model model = new 
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) { NotifyPropertyChanged(e.PropertyName + "VM"); };
        }

        public void StartGame()
        {
            string command = "generate";
            command += Properties.Settings.Default.MazeName + Properties.Settings.Default.MazeRows + Properties.Settings.Default.MazeCols;
            //call connect in model (client)
        }
    }
}
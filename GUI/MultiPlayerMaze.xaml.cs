﻿using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MultiPlayerMaze.xaml
    /// </summary>
    public partial class MultiPlayerMaze : Window
    {
        public int MazeRows { get; set; }
        public int MazeCols { get; set; }
        public string MazeString { get; set; }
        public Position InitialPos { get; set; }
        public Position GoalPos { get; set; }
        private MultiPlayerMazeVM mpVM;

        public MultiPlayerMaze(string str)
        {
            InitializeComponent();
            mpVM = new MultiPlayerMazeVM(str);
            this.DataContext = mpVM;
            this.KeyDown += MyBoard.Viewbox_KeyDown;
            MyBoard.MovingUp += new EventHandler(GoUp);
            MyBoard.MovingDown += new EventHandler(GoDown);
            MyBoard.MovingLeft += new EventHandler(GoLeft);
            MyBoard.MovingRight += new EventHandler(GoRight);
            mpVM.ChangeOtherLoc += new EventHandler(moveOpponent);
        }
        public MultiPlayerMaze(int rows, int cols, string name)
        {
            InitializeComponent();
            mpVM = new MultiPlayerMazeVM(rows, cols, name);
            this.DataContext = mpVM;
            this.KeyDown += MyBoard.Viewbox_KeyDown;
            MyBoard.MovingUp += new EventHandler(GoUp);
            MyBoard.MovingDown += new EventHandler(GoDown);
            MyBoard.MovingLeft += new EventHandler(GoLeft);
            MyBoard.MovingRight += new EventHandler(GoRight);
            mpVM.ChangeOtherLoc += new EventHandler(moveOpponent);
        }
        private void moveOpponent(object sender, EventArgs e)
        {
            Position temp;
            switch (mpVM.Direction)
            {
               
                case "up":
                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(--temp.Row, temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                case "down":
                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(++temp.Row, temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                case "left":
                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(temp.Row, --temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                case "right":
                    temp = this.OtherBoard.Current;
                    OtherBoard.Current = new Position(temp.Row, ++temp.Col);
                    OtherBoard.UpdateLoc();
                    break;
                default:
                    break;
            }
        }

        private void GoRight(object sender, EventArgs e)
        {
            mpVM.MovementNotify("right");
        }

        private void GoLeft(object sender, EventArgs e)
        {
            mpVM.MovementNotify("left");
        }

        private void GoDown(object sender, EventArgs e)
        {
            mpVM.MovementNotify("down");
        }

        private void GoUp(object sender, EventArgs e)
        {
            mpVM.MovementNotify("up");
        }

        private void BackToMainWin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}

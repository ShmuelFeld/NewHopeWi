﻿using System;
using System.Collections.Generic;
using System.Text;
using MazeLib;
using SearchAlgoritmLib;

namespace ModelClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class MazeSolution
    {
        /// <summary>
        /// The back trace
        /// </summary>
        private Stack<State<Position>> backTrace;
        private int evaluatedNodes;
        /// <summary>
        /// Initializes a new instance of the <see cref="MazeSolution"/> class.
        /// </summary>
        /// <param name="bt">The bt.</param>
        public MazeSolution(Stack<State<Position>> bt, int evaluated)
        {
            backTrace = bt;
            this.evaluatedNodes = evaluated;
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public new string ToString()
        {
            string solution = "";
            Stack<State<Position>> temp = backTrace;
            State<Position> prev = temp.Pop();
            while (temp.Any())
            {
                State<Position> cur = temp.Pop();
                int pRow = prev.Instance.Row;
                int pCol = prev.Instance.Col;
                int cRow = cur.Instance.Row;
                int cCol = cur.Instance.Col;
                //left
                if (pCol > cCol)
                {
                    solution += "0";
                }
                //right
                if (pCol < cCol)
                {
                    solution += "1";
                }
                //up
                if (pRow > cRow)
                {
                    solution += "2";
                }
                //down
                if (pRow < cRow)
                {
                    solution += "3";
                }
                prev = cur;
            }
            return solution;
        }

        /// <summary>
        /// To the json.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /*public string ToJSON(string name)
        {
            JObject solveObj = new JObject();
            solveObj["Name"] = name;
            solveObj["solution"] = ToString();
            solveObj["NodesEvaluated"] = this.evaluatedNodes;
            return solveObj.ToString();
        }*/
    }
}

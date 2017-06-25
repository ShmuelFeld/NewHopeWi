using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MazeLib;
using ModelCL;

namespace WebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class WebModel
    {
        /// <summary>
        /// The model
        /// </summary>
        static private IModel model;
        /// <summary>
        /// Initializes a new instance of the <see cref="WebModel"/> class.
        /// </summary>
        public WebModel()
        {
            model = new Model();
        }

        /// <summary>
        /// Generates the maze.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <returns></returns>
        public string GenerateMaze(string name, int rows, int cols)
        {
            return model.GenerateMaze(name, rows, cols).ToJSON();            
        }

        /// <summary>
        /// Solves the maze.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns></returns>
        public MazeSolution SolveMaze(string name, int algorithm)
        {
            return model.SolveMaze(name, algorithm);
        }
    }
}
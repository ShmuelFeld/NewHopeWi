using MazeLib;
using ModelCL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class MazeController : ApiController
    {
        /// <summary>
        /// The model
        /// </summary>
        static private WebModel model = new WebModel();

        // GET: api/GenerateMaze/5
        /// <summary>
        /// Generates the maze.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GenerateMaze/{name}/{rows}/{cols}")]
        public JObject GenerateMaze(string name, int rows, int cols)
        {
            Maze maze = Maze.FromJSON(model.GenerateMaze(name, rows, cols));
            JObject obj = JObject.Parse(maze.ToJSON());
            return obj;
        }

        /// <summary>
        /// Solves the maze.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/SolveMaze/{name}/{algorithm}")]
        public JObject SolveMaze(string name, int algorithm)
        {
            MazeSolution solution = model.SolveMaze(name, algorithm);
            JObject obj = JObject.Parse(solution.ToJSON(name));
            return obj;
        }
    }
}

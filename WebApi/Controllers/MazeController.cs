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

    public class MazeController : ApiController
    {
        static WebModel model = new WebModel();
        //// GET: api/GenerateMaze
        //public IEnumerable<Maze> Get()
        //{
        //    return null;
        //}

        // GET: api/GenerateMaze/5
        [HttpGet]
        [Route("api/GenerateMaze/{name}/{rows}/{cols}")]
        public JObject GenerateMaze(string name, int rows, int cols)
        {
            Maze maze = Maze.FromJSON(model.GenerateMaze(name, rows, cols));
            JObject obj = JObject.Parse(maze.ToJSON());
            return obj;
        }

        [HttpGet]
        [Route("api/SolveMaze/{name}/{algorithm}")]
        public JObject SolveMaze(string name, int algorithm)
        {
            //model.GenerateMaze(name, 12, 12);
            MazeSolution solution = model.SolveMaze(name, algorithm);
            JObject obj = JObject.Parse(solution.ToJSON(name));
            return obj;
        }

        // POST: api/GenerateMaze
        public void Post(Maze m)
        {

        }

        // PUT: api/GenerateMaze/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GenerateMaze/5
        public void Delete(int id)
        {
        }
    }
}

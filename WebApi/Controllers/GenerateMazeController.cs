using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class GenerateMazeController : ApiController
    {
        // GET: api/GenerateMaze
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GenerateMaze/5
        public string Get(string str)
        {
            return str;
        }

        // POST: api/GenerateMaze
        [HttpPost]
        public void GenerateMaze(Maze m)
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

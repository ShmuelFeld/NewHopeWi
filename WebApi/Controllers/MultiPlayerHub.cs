using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WebApi.Models;
using System.Web.Http;
using MazeLib;

namespace WebApi
{
    [HubName("multiplayerHub")]
    public class MultiPlayerHub : Hub
    {
        static private WebModel model = new WebModel();

        //[HttpGet]
        //[Route("api/GetList")]
        //public IEnumerable<Maze> GetList()
        //{
        //    return model.GetList();
        //}

        public void Start(string name, int rows, int cols)
        {
            Maze maze = model.StartGame(name, rows, cols, Context.ConnectionId);
            Clients.All.drawMaze(maze.ToJSON());
        }

        public void join()
        {
            Maze maze = model.JoinGame("m", Context.ConnectionId);
            Clients.All.drawMaze(maze.ToJSON());
        }
    }
}
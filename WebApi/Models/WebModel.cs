using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MazeLib;
using ModelCL;

namespace WebApi.Models
{
    public class WebModel
    {
        static private IModel model;
        public WebModel()
        {
            model = new Model();
        }

        public string GenerateMaze(string name, int rows, int cols)
        {
            return model.GenerateMaze(name, rows, cols).ToJSON();            
        }

        public MazeSolution SolveMaze(string name, int algorithm)
        {
            return model.SolveMaze(name, algorithm);
        }

        public Maze StartGame(string name, int rows, int cols, string clientId)
        {
            return model.StartGame(name, rows, cols, clientId);
        }

        public List<Maze> GetList()
        {
            return model.GetListOfAvailableGames();
        }

        public Maze JoinGame(string name, string clientId)
        {
            return model.Join(name, clientId);
        }

        public MultiPlayerGame Play(string move, string clientId)
        {
            return model.Play(move, clientId);
        }
    }
}
using MazeLib;
using ModelCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MultiModel
    {
        IModel model = new Model();

        public MultiModel()
        {
            model = new Model();
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

        public MultiPlayerGame Play(string clientId)
        {
            return model.Play(clientId);
        }
    }
}
using MazeLib;
using ModelCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MultiModel
    {
        /// <summary>
        /// The model
        /// </summary>
        IModel model = new Model();

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiModel"/> class.
        /// </summary>
        public MultiModel()
        {
            model = new Model();
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        public Maze StartGame(string name, int rows, int cols, string clientId)
        {
            return model.StartGame(name, rows, cols, clientId);
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public List<Maze> GetList()
        {
            return model.GetListOfAvailableGames();
        }

        /// <summary>
        /// Joins the game.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        public Maze JoinGame(string name, string clientId)
        {
            return model.Join(name, clientId);
        }

        /// <summary>
        /// Plays the specified client identifier.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        public MultiPlayerGame Play(string clientId)
        {
            return model.Play(clientId);
        }
    }
}
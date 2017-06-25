using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WebApi.Models;
using System.Web.Http;
using MazeLib;
using Newtonsoft.Json.Linq;
using ModelCL;

namespace WebApi
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.SignalR.Hub" />
    [HubName("multiplayerHub")]
    public class MultiPlayerHub : Hub
    {
        /// <summary>
        /// The model
        /// </summary>
        static private MultiModel model = new MultiModel();

        /// <summary>
        /// Starts the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        public void Start(string name, int rows, int cols)
        {
            string clientId = Context.ConnectionId;
            Maze maze = model.StartGame(name, rows, cols, clientId);
            Clients.Client(clientId).drawMaze(JObject.Parse(maze.ToJSON()));
        }

        /// <summary>
        /// Joins the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void Join(string name)
        {
            string clientId = Context.ConnectionId;
            Maze maze = model.JoinGame(name, clientId);
            string j = maze.ToJSON();
            JObject p = JObject.Parse(j);
            Clients.Client(clientId).drawMaze(JObject.Parse(maze.ToJSON()));
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns></returns>
        public string[] List()
        {
            List<Maze> list = model.GetList();
            return ToJSON(list);
        }

        /// <summary>
        /// To the json.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        private string[] ToJSON(List<Maze> list)
        {
            string[] namesList = new string[list.Count];
            int i = 0;
            foreach (Maze m in list)
            {
                namesList[i] = m.Name;
                i++;
            }
            return namesList;
        }

        /// <summary>
        /// Plays the specified move.
        /// </summary>
        /// <param name="move">The move.</param>
        public void Play(int move)
        {
            if (move >= 37 && move <= 40)
            {
                string client = Context.ConnectionId;
                MultiPlayerGame game = model.Play(client);
                string otherClient = null;
                if (game.FirstPlayer == client)
                {
                    otherClient = game.GetSecondPlayer();
                }
                else if (game.GetSecondPlayer() == client)
                {
                    otherClient = game.FirstPlayer;
                }
                Clients.Client(otherClient).moveOther(move);
            }
        }
    }
}
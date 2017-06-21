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
    [HubName("multiplayerHub")]
    public class MultiPlayerHub : Hub
    {
        static private WebModel model = new WebModel();

        public void Start(string name, int rows, int cols)
        {
            string clientId = Context.ConnectionId;
            Maze maze = model.StartGame(name, rows, cols, clientId);
            Clients.Client(clientId).drawMaze(JObject.Parse(maze.ToJSON()));
        }

        public void Join(string name)
        {
            string clientId = Context.ConnectionId;
            Maze maze = model.JoinGame(name, clientId);
            Clients.Client(clientId).drawMaze(JObject.Parse(maze.ToJSON()));
        }

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
            }
            return namesList;
        }

        public void Play(string move)
        {
            if ((move == "ArrowUp") || (move == "ArrowDown") || (move == "ArrowRight") || (move == "ArrowLeft"))
            {
                string client = Context.ConnectionId;
                MultiPlayerGame game = model.Play(move, client);
                string otherClient = null;
                if (game.FirstPlayer == client)
                {
                    otherClient = game.GetSecondPlayer();
                }
                else if (game.GetSecondPlayer() == client)
                {
                    otherClient = game.FirstPlayer;
                }
                //view.SendToOtherClient(ToJSON(game.GetMazeName(), move), tcpOfOtherClient);
            }
        }
    }
}
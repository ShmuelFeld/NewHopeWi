﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewHope
{
    /// <summary>
    /// represent the play command
    /// </summary>
    /// <seealso cref="ex1.ICommand" />
    public class PlayCommand : ICommand
    {
        /// <summary>
        /// The model
        /// </summary>
        private IModel model;
        /// <summary>
        /// The view
        /// </summary>
        private IView view;
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public PlayCommand(IModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// Sets the view.
        /// </summary>
        /// <param name="v">The v.</param>
        public void SetView(IView v) { view = v; }
        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        public string Execute(string[] args, TcpClient client)
        {
            string move = args[0];
            if ((move != "up") && (move != "down") && (move != "right") && (move != "left")) { return "invalid move"; }
            MultiPlayerGame game = model.Play(move, client);
            TcpClient tcpOfOtherClient = null;
            if (game.FirstPlayer == client)
            {
                tcpOfOtherClient = game.GetSecondPlayer();
            }
            else if (game.GetSecondPlayer() == client)
            {
                tcpOfOtherClient = game.FirstPlayer;
            }
            view.SendToOtherClient(ToJSON(game.GetMazeName(), move), tcpOfOtherClient);
            return "other player has been notified";
        }
        /// <summary>
        /// To the json.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="move">The move.</param>
        /// <returns></returns>
        public string ToJSON(string name, string move)
        {
            JObject moveObj = new JObject();
            moveObj["Name"] = name;
            moveObj["Direction"] = move;
            return moveObj.ToString();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewHope
{
    /// <summary>
    /// 
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Sets the model.
        /// </summary>
        /// <param name="model">The model.</param>
        void SetModel(IModel model);
        /// <summary>
        /// Sets the view.
        /// </summary>
        /// <param name="view">The view.</param>
        void SetView(IView view);
        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="command">The command.</param>
        void AddCommand(string s, ICommand command);
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="commandLine">The command line.</param>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        string ExecuteCommand(string commandLine, TcpClient client);
    }
}

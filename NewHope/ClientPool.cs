﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewHope
{
    /// <summary>
    /// holds all the clients.
    /// </summary>
    class ClientPool
    {
        /// <summary>
        /// The server
        /// </summary>
        private Server server;
        /// <summary>
        /// The list of clients
        /// </summary>
        private List<ClientDescriptor> listOfClients;
        /// <summary>
        /// The controller
        /// </summary>
        private IController controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientPool"/> class.
        /// </summary>
        /// <param name="ser">The ser.</param>
        public ClientPool(Server ser)
        {
            this.server = ser;
            this.listOfClients = new List<ClientDescriptor>();
            controller = new Controller();
        }
        /// <summary>
        /// Adds a client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="ser">The ser.</param>
        public void AddClient(TcpClient client, Server ser)
        {
            ClientDescriptor cli = new ClientDescriptor(client, controller);
            cli.AddCommandToClose("generate");
            cli.AddCommandToClose("solve");
            cli.AddCommandToClose("close");
            cli.AddCommandToClose("list");
            this.listOfClients.Add(cli);
            //  cli.addObserver(ser);

        }
        /// <summary>
        /// Closes the communication with all clients.
        /// </summary>
        public void CloseCommunication()
        {
            foreach (ClientDescriptor item in this.listOfClients)
            {
                item.SetClose();
            }
        }
        /// <summary>
        /// Closes the communication with a specific client.
        /// </summary>
        /// <param name="client">The client.</param>
        public void CloseCommunication(TcpClient client)
        {
            foreach (ClientDescriptor item in this.listOfClients)
            {
                if (item.TcpClient.Equals(client))
                {
                    item.SetClose();
                }
            }
        }
    }
}

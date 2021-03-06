﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewHope
{
    /// <summary>
    /// object that implement this interface is the view tier.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Sends to other client.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="otherClient">The other client.</param>
        void SendToOtherClient(string data, TcpClient otherClient);
    }
}

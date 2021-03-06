﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHope
{
    /// <summary>
    /// the main.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Server ser = new Server();
            IController controller = new Controller();
            ser.SetController(controller);
            ser.StartToListen();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApi
{
    [HubName("multiplayerHub")]
    public class MultiPlayerHab : Hub
    {

        public void Hello()
        {
            Clients.All.broadcastMessage("hello");
        }
    }
}
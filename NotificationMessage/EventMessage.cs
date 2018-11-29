using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavFunService.HavFunMessage
{
    public class EventMessage:IMessage
    {
        private string EventDescription;
        private string BarID;
        private string EventDate;
        public void SendAsyncNotification()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<Hub>();
            context.Clients.All.EventMessage(JsonConvert.SerializeObject(this));
        }
    }
}

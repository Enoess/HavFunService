using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavFunService.HavFunMessage
{
    public class FriendCloseMessage
    {
        private string Localisation;
        private string FriendId;
        public void SendAsyncNotification()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<Hub>();
            context.Clients.All.FriendCloseMessage(JsonConvert.SerializeObject(this));
        }
    }
}

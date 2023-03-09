using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHelper.Core.DiscordBot
{
    public class PendingCommand
    {
        public string Name { get; private set; }
        public Action Handler { get; private set; }
        public object Sender { get; private set; }

        public PendingCommand(string name, Action handler, object sender)
        {
            Name = name;
            Handler = handler;
            Sender = sender;
        }
    }
}

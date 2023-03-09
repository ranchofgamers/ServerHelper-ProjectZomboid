using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHelper.Core.DiscordBot
{
    public class CommandConfig
    {
        public string Prefix { get; }
        public string Name { get; }
        public string Description { get; }
        public ulong[] ChannelIds { get; }
        public string[] Roles { get; }
        public bool RunFromChat { get; }
        public bool RunFromCode { get; }

        public CommandConfig(string prefix, string name, string description, ulong[] channelIds, string[] roles, bool runFromChat, bool runFromCode)
        {
            Prefix = prefix;
            Name = name;
            Description = description;
            ChannelIds = channelIds;
            Roles = roles;
            RunFromChat = runFromChat;
            RunFromCode = runFromCode;
        }
    }
}

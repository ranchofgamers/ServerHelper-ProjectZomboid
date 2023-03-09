using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace ServerHelper.Core.DiscordBot
{
    public interface ICommand
    {
        CommandConfig Config { get; set; }
        Task FromChatHandler(BotShell bot, SocketMessage msg);
        Task FromCodeHandler(BotShell bot, object[] args);
    }
}

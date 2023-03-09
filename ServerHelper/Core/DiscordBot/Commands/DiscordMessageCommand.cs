using Discord;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServerHelper.Core.DiscordBot.Commands
{
    public class DiscordMessageCommand : ICommand
    {
        public CommandConfig Config { get; set; }

        public Task FromChatHandler(BotShell bot, SocketMessage msg)
        {
            throw new NotImplementedException();
        }
        public async Task FromCodeHandler(BotShell bot, object[] args)
        {
            ulong cannelid;
            string msg;

            if (args.Length == 0)
                throw new ArgumentException("Не переданы аргументы, команда ожидала ulong ID канала в качестве первого аргумента и string сообщение в качестве второго.");
            try
            {
                cannelid = (ulong)args[0];
                msg = (string)args[1];
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException("Команда ожидала ulong ID канала в качестве первого аргумента и string собщение в качестве второго аргумента: " + ex.Message);
            }

            await bot.SendMessageAsync(cannelid, msg);
        }
    }
}

using Discord.WebSocket;
using Microsoft.VisualBasic.Devices;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ServerHelper.Core.DiscordBot.Commands
{
    public class PerformanceCommand : ICommand
    {
        public CommandConfig Config { get; set; }

        public async Task FromChatHandler(BotShell bot, SocketMessage msg)
        {
            await msg.Channel.SendMessageAsync("Начал расчёт...");

            var cup = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var availRam = new PerformanceCounter("Memory", "Available MBytes");
            cup.NextValue();
            availRam.NextValue();
            Thread.Sleep(5000);

            ComputerInfo myCompInfo = new ComputerInfo();
            ulong bytesPerMebibyte = (1 << 20);
            ulong physicalMemory = myCompInfo.TotalPhysicalMemory / bytesPerMebibyte;

            string message =
            $"```ARM\r\n" +
            $"CPU: {Math.Round(cup.NextValue(), 2)} % \r\n" +
            $"RAM: {physicalMemory - availRam.NextValue()}/{physicalMemory} Mb" +
            $"```";

            await msg.Channel.SendMessageAsync(message);
        }
        public Task FromCodeHandler(BotShell bot, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}

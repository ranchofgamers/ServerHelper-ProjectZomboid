using Discord.WebSocket;
using Microsoft.VisualBasic.Devices;
using ServerHelper.Forms;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ServerHelper.Core.DiscordBot.Commands
{
    public class HelpCommand : ICommand
    {
        public CommandConfig Config { get; set; }

        public async Task FromChatHandler(BotShell bot, SocketMessage msg)
        {
            DiscordForm discordForm;
            discordForm = ModuleManager.Modules.Find(m => m.GetType() == typeof(DiscordForm)) as DiscordForm;

            string message = string.Empty;
            int counter = 0;

            foreach (var command in bot.CommandsList.Commands)
            {
                if (!command.Config.RunFromChat)
                    continue;

                string roles = "everyone; ";
                if (command.Config.Roles != null)
                {
                    roles = string.Empty;
                    foreach (var role in command.Config.Roles)
                        roles += $"{role}; ";
                }

                string channels = "eny; ";
                if (command.Config.ChannelIds != null)
                {
                    channels = string.Empty;
                    foreach (var id in command.Config.ChannelIds)
                    {
                        try
                        {
                            var channel = bot.GetGuild().GetChannel(id);
                            if (channel == null)
                            {
                                channels += $"unknown channel; ";
                                continue;
                            }
                            channels += $"{channel.Name}; ";
                        }
                        catch (Exception)
                        {
                            channels += $"unknown channel; ";
                            continue;
                        }
                    }
                }

                counter++;
                var line = $"{counter}. {command.Config.Prefix}{command.Config.Name} - {command.Config.Description}. #Доступна: {roles} #В каналах: {channels} \r\n";
                message += line;
            }

            message =
            $"```YAML\r\n" +
            $"{message}" +
            $"```";

            await msg.Channel.SendMessageAsync(message);
        }
        public Task FromCodeHandler(BotShell bot, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
